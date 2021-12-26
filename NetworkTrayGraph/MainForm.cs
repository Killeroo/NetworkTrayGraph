using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace NetworkTrayGraph
{
    /// <summary>
    /// Main form, acts as a setting window for application
    /// </summary>
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyIcon(IntPtr hIcon);

        private GraphSettings _graphSettings = new GraphSettings();
        private NetworkMonitor _monitor = new NetworkMonitor();
        private GraphBuilder _graphCreator = new GraphBuilder();

        /// <summary>
        /// These queues store the current bytes that have been processed 
        /// by the available and enabled network interfaces over the last 16 intervals 
        /// (the graph bitmap can only hold 14 columns)
        /// </summary>
        private Queue<long> _currentReceiveThroughput = new Queue<long>();
        private Queue<long> _currentSendThroughput = new Queue<long>();

        /// <summary>
        /// We also keep track of the bytes per second for the icon tool tip
        /// </summary>
        private long _totalSentBytesPerSecond = 0;
        private long _totalReceivedBytesPerSecond = 0;

        private Bitmap _graphIconBitmap;
        private IntPtr _graphIconHandle;

        /// <summary>
        /// Holds the current state of the form, if it can close or if it can be displayed
        /// Note: Functionality for starting the form hidden was based off this excellent answer
        ///       https://stackoverflow.com/a/1732294
        /// </summary>
        private bool _allowVisible;
        private bool _allowClose;

        public MainForm()
        {
            InitializeComponent();

            // Add an application exit event
            Application.ApplicationExit += OnApplicationExit;

            // Load interfaces on startup
            _graphSettings.EnabledInterfaces = _monitor.GetAvailableInterfaceNames().ToDictionary(i => i, x => true);
            UpdateAvailableInterfacesListView();


            if (!string.IsNullOrEmpty(Properties.Settings.Default.SettingDataString))
            {
                // Try and load graph settings from program settings
                _graphSettings.FromString(Properties.Settings.Default.SettingDataString);
            }

            // Populate the ui
            PopulateUiFromSettings();
        }

        /// <summary>
        /// Updates a throughput data queue (either the send or recieve queue) with most recent data from each interface,
        /// it also limits the size of the queue. The graph icon can only display 14 columns
        /// </summary>
        /// <param name="throughputQueue"></param>
        /// <param name="lastBytes"></param>
        /// <param name="currentBytes"></param>
        /// <returns></returns>
        private long UpdateThroughputQueue(ref Queue<long> throughputQueue, List<long> lastBytes, List<long> currentBytes)
        {
            long bytes = 0;
            for (int i = 0; i < lastBytes.Count; i++)
            {
                bytes += currentBytes[i] - lastBytes[i];
            }

            throughputQueue.Enqueue(Math.Abs(bytes));

            if (throughputQueue.Count > 14)
                throughputQueue.Dequeue();
            return bytes;
        }

        /// <summary>
        /// Generates a human readable speed string from a number of bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private string GenerateSpeedString(long bytes)
        {
            float convertedValue = 0;
            string suffix = "";
            if (bytes > 1024 * 1000)
            {
                if (bytes > 1024 * 1024 * 1000)
                {
                    convertedValue = Helper.ToGigabytes((float)bytes);
                    suffix = "GB/s";
                }
                else
                {
                    convertedValue = Helper.ToMegabytes((float)bytes);
                    suffix = "MB/s";
                }
            }
            else
            {
                convertedValue = Helper.ToKilobytes((float)bytes);
                suffix = "KB/s";
            }

            return string.Format("{0}{1}", convertedValue, suffix);
        }

        /// <summary>
        /// Fills the forms ui elements with the contents of the form's GraphSettings
        /// </summary>
        /// <see cref="MainForm._graphSettings"/>
        private void PopulateUiFromSettings()
        {
            UpdateIntervalNumericUpDown.Value = _graphSettings.UpdateInterval;
            ReceivedBodyColorTextBox.BackColor = _graphSettings.ReceivedBodyColor;
            ReceivedHighlightColorTextBox.BackColor = _graphSettings.ReceivedHighlightColor;
            SentBodyColorTextBox.BackColor = _graphSettings.SentBodyColor;
            SentHighlightColorTextBox.BackColor = _graphSettings.SentHighlightColor;
            LinearRadioButton.Checked = _graphSettings.Scale == GraphScale.Linear ? true : false;
            LogarithmicRadioButton.Checked = _graphSettings.Scale == GraphScale.Logarithmic ? true : false;
            MaxGraphYValueNumericUpDown.Value = _graphSettings.MaxDisplayValue;
        }

        /// <summary>
        /// Populates the form's settings object with the UI element's values
        /// </summary>
        /// <see cref="MainForm._graphSettings"/>
        private void PopulateSettingsFromUi()
        {
            _graphSettings.UpdateInterval = Convert.ToInt32(UpdateIntervalNumericUpDown.Value);
            _graphSettings.ReceivedBodyColor = ReceivedBodyColorTextBox.BackColor;
            _graphSettings.ReceivedHighlightColor = ReceivedHighlightColorTextBox.BackColor;
            _graphSettings.SentBodyColor = SentBodyColorTextBox.BackColor;
            _graphSettings.SentHighlightColor = SentHighlightColorTextBox.BackColor;
            _graphSettings.Scale = LinearRadioButton.Checked ? GraphScale.Linear : GraphScale.Logarithmic;
            _graphSettings.MaxDisplayValue = Convert.ToInt32(MaxGraphYValueNumericUpDown.Value);
        }

        private void UpdateAvailableInterfacesListView()
        {
            InterfacesTreeView.Nodes.Clear();

            foreach (var @interface in _graphSettings.EnabledInterfaces)
            {
                TreeNode node = new TreeNode(@interface.Key);
                node.Checked = @interface.Value;
                InterfacesTreeView.Nodes.Add(node);
            }
        }

        /// <summary>
        /// Code run every time the update timer ticks, this is the core code of the application.
        /// It gets the latest bytes sent and received from each interface, generates a graph bitmap
        /// and generates it's tooltip text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void UpdateTimer_OnTick(object sender, EventArgs e)
        {
            // Get latest network data from monitor
            _monitor.Update(_graphSettings);

            // Add data to queue of current data to be displayed on graph
            _totalSentBytesPerSecond = UpdateThroughputQueue(
                ref _currentSendThroughput,
                _monitor.InterfaceStats.Select(x => x.Value.LastSentBytes).ToList(),
                _monitor.InterfaceStats.Select(x => x.Value.SentBytes).ToList());
            _totalReceivedBytesPerSecond = UpdateThroughputQueue(
                ref _currentReceiveThroughput,
                _monitor.InterfaceStats.Select(x => x.Value.LastReceivedBytes).ToList(),
                _monitor.InterfaceStats.Select(x => x.Value.ReceivedBytes).ToList());

            // Create the graph bitmap
            _graphIconBitmap = _graphCreator.CreateBitmap(
                _currentReceiveThroughput.ToList(),
                _currentSendThroughput.ToList(),
                _graphSettings);

            // Update preview
            PreviewPictureBox.Image = new Bitmap(_graphIconBitmap, new Size(64, 64));
            TooltipTextBox.Text = string.Format(
                "R: {0}" + Environment.NewLine + 
                "S: {1}",
                GenerateSpeedString(_totalReceivedBytesPerSecond),
                GenerateSpeedString(_totalSentBytesPerSecond));

            // Update NotifyIcon with graph and tooltip text
            string tooltipText = string.Format(
                "Received: {0}\n" +
                "Sent: {1}",
                GenerateSpeedString(_totalReceivedBytesPerSecond),
                GenerateSpeedString(_totalSentBytesPerSecond));
            _graphIconHandle = (_graphIconBitmap.GetHicon());
            GraphNotifyIcon.Icon = System.Drawing.Icon.FromHandle(_graphIconHandle);
            GraphNotifyIcon.Text = tooltipText;

            // Destroy handle to prevent memory leak
            if (_graphIconHandle != null) DestroyIcon(_graphIconHandle);
        }

        #region Overriden functions

        /// <summary>
        /// Override the visible core to add our show and hide functionality
        /// </summary>
        /// <param name="value"></param>
        protected override void SetVisibleCore(bool value)
        {
            if (!_allowVisible)
            {
                value = false;
                if (!this.IsHandleCreated) CreateHandle();
            }
            base.SetVisibleCore(value);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_allowClose)
            {
                this.Hide();
                e.Cancel = true;
            }
            base.OnFormClosing(e);
        }

        #endregion

        #region Callback functions 

        /// <summary>
        /// Runs each time the interface timer ticks, this timer refreshes the list of available interfaces
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InterfaceCheckTimer_OnTick(object sender, EventArgs e)
        {
            Dictionary<string, bool> newEnabledInterfaces = new Dictionary<string, bool>();
            List<string> availableInterfaceNames = _monitor.GetAvailableInterfaceNames();

            foreach (var interfaceName in availableInterfaceNames)
            {
                // If an entry for the interface existed before, copy over if it was enabled,
                // if not enable it by default
                newEnabledInterfaces.Add(
                    interfaceName,
                    _graphSettings.EnabledInterfaces.ContainsKey(interfaceName) ? _graphSettings.EnabledInterfaces[interfaceName] : true);
            }
            _graphSettings.EnabledInterfaces = newEnabledInterfaces;

            UpdateAvailableInterfacesListView();

            _monitor.PruneInterfaceStatistics(_graphSettings);
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            GraphNotifyIcon.Dispose();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            PopulateSettingsFromUi();

            UpdateTimer.Interval = _graphSettings.UpdateInterval;

            // Save the settings data
            Properties.Settings.Default.SettingDataString = _graphSettings.ToString();
            Properties.Settings.Default.Save();

            _allowVisible = false;
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _allowVisible = false;
            this.Hide();
        }

        private void InterfacesTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            _graphSettings.EnabledInterfaces[e.Node.Text] = e.Node.Checked;
        }

        private void LogarithmicRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label5.Enabled = !LogarithmicRadioButton.Checked;
            label6.Enabled = !LogarithmicRadioButton.Checked;
            MaxGraphYValueNumericUpDown.Enabled = !LogarithmicRadioButton.Checked;
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allowVisible = true;
            Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allowClose = true;
            Application.Exit();
        }

        private void GraphNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            _allowVisible = true;
            Show();
        }

        private void GraphNotifyIcon_Click(object sender, MouseEventArgs e)
        {
            _allowVisible = true;
            Show();
        }


        private void SentBodyColorEditButton_Click(object sender, EventArgs e)
        {
            ColorPickerDialog = new ColorDialog();
            ColorPickerDialog.Color = SentBodyColorTextBox.BackColor;
            ColorPickerDialog.AllowFullOpen = true;
            ColorPickerDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (ColorPickerDialog.ShowDialog(this) == DialogResult.OK)
            {
                SentBodyColorTextBox.BackColor = ColorPickerDialog.Color;
            }
        }

        private void SentHighlightColorEditButton_Click(object sender, EventArgs e)
        {
            ColorPickerDialog = new ColorDialog();
            ColorPickerDialog.Color = SentHighlightColorTextBox.BackColor;
            ColorPickerDialog.AllowFullOpen = true;
            ColorPickerDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (ColorPickerDialog.ShowDialog(this) == DialogResult.OK)
            {
                ReceivedHighlightColorTextBox.BackColor = ColorPickerDialog.Color;
            }
        }

        private void ReceivedBodyColorEditButton_Click(object sender, EventArgs e)
        {
            ColorPickerDialog = new ColorDialog();
            ColorPickerDialog.Color = ReceivedBodyColorTextBox.BackColor;
            ColorPickerDialog.AllowFullOpen = true;
            ColorPickerDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (ColorPickerDialog.ShowDialog(this) == DialogResult.OK)
            {
                ReceivedBodyColorTextBox.BackColor = ColorPickerDialog.Color;
            }
        }

        private void ReceivedHighlightColorEditButton_Click(object sender, EventArgs e)
        {
            ColorPickerDialog = new ColorDialog();
            ColorPickerDialog.Color = ReceivedHighlightColorTextBox.BackColor;
            ColorPickerDialog.AllowFullOpen = true;
            ColorPickerDialog.FullOpen = true;
            //colorDialog.StartPosition = FormStartPosition.CenterParent;

            if (ColorPickerDialog.ShowDialog(this) == DialogResult.OK)
            {
                ReceivedHighlightColorTextBox.BackColor = ColorPickerDialog.Color;
            }
        }


        #endregion

    }
}
