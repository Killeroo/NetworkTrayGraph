using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chasovoy
{
    public partial class SettingsForm : Form
    {
        private NetworkMonitor monitor = new NetworkMonitor();
        private GraphBitmapFactory graphCreator = new GraphBitmapFactory();
        private Queue<int> currentNetworkThroughput = new Queue<int>();

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void UpdateTimer_OnTick(object sender, EventArgs e)
        {
            // Get latest network data from monitor
            monitor.Update();

            // Add data to queue of current data to be displayed on graph
            int receivedKbps = 0;
            foreach (var stat in monitor.InterfaceStats)
            {
                receivedKbps += (int) (stat.Value.recv - stat.Value.lastRecv) / 1000;
            }

            currentNetworkThroughput.Enqueue(receivedKbps);

            if (currentNetworkThroughput.Count > 14)
                currentNetworkThroughput.Dequeue();


            Bitmap m = graphCreator.CreateGraph(currentNetworkThroughput);
            IntPtr hIcon = (m.GetHicon());

            graphNotifyIcon.Icon = System.Drawing.Icon.FromHandle(hIcon);

            graphNotifyIcon.Text = receivedKbps + "KB/s";

            //DestroyIcon(hIcon.ToInt32);
        }
    }
}
