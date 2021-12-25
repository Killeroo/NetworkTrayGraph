
namespace NetworkTrayGraph
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GraphNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.ReceiveColorTextBox = new System.Windows.Forms.TextBox();
            this.InterfacesTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SendColorTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ReceiveColorEditButton = new System.Windows.Forms.Button();
            this.InterfaceCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.UpdateIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SendColorEditButton = new System.Windows.Forms.Button();
            this.ColorPickerDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LinearRadioButton = new System.Windows.Forms.RadioButton();
            this.LogarithmicRadioButton = new System.Windows.Forms.RadioButton();
            this.MaxGraphYValueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NotifyIconContextMenuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxGraphYValueNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphNotifyIcon
            // 
            this.GraphNotifyIcon.ContextMenuStrip = this.NotifyIconContextMenuStrip;
            this.GraphNotifyIcon.Text = "notifyIcon1";
            this.GraphNotifyIcon.Visible = true;
            this.GraphNotifyIcon.DoubleClick += new System.EventHandler(this.GraphNotifyIcon_DoubleClick);
            // 
            // NotifyIconContextMenuStrip
            // 
            this.NotifyIconContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.NotifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TitleToolStripMenuItem,
            this.toolStripSeparator2,
            this.SettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.NotifyIconContextMenuStrip.Name = "NotifyIconContextMenuStrip";
            this.NotifyIconContextMenuStrip.Size = new System.Drawing.Size(173, 82);
            // 
            // TitleToolStripMenuItem
            // 
            this.TitleToolStripMenuItem.Enabled = false;
            this.TitleToolStripMenuItem.Name = "TitleToolStripMenuItem";
            this.TitleToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.TitleToolStripMenuItem.Text = "NetworkTrayGraph";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.SettingsToolStripMenuItem.Text = "Settings";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_OnTick);
            // 
            // ReceiveColorTextBox
            // 
            this.ReceiveColorTextBox.Enabled = false;
            this.ReceiveColorTextBox.Location = new System.Drawing.Point(96, 42);
            this.ReceiveColorTextBox.Name = "ReceiveColorTextBox";
            this.ReceiveColorTextBox.Size = new System.Drawing.Size(47, 20);
            this.ReceiveColorTextBox.TabIndex = 5;
            // 
            // InterfacesTreeView
            // 
            this.InterfacesTreeView.CheckBoxes = true;
            this.InterfacesTreeView.Location = new System.Drawing.Point(6, 14);
            this.InterfacesTreeView.Name = "InterfacesTreeView";
            this.InterfacesTreeView.Size = new System.Drawing.Size(273, 99);
            this.InterfacesTreeView.TabIndex = 7;
            this.InterfacesTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.InterfacesTreeView_AfterCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Received Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sent Color";
            // 
            // SendColorTextBox
            // 
            this.SendColorTextBox.Enabled = false;
            this.SendColorTextBox.Location = new System.Drawing.Point(96, 68);
            this.SendColorTextBox.Name = "SendColorTextBox";
            this.SendColorTextBox.Size = new System.Drawing.Size(47, 20);
            this.SendColorTextBox.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PreviewPictureBox);
            this.groupBox2.Location = new System.Drawing.Point(210, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(87, 92);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // PreviewPictureBox
            // 
            this.PreviewPictureBox.Location = new System.Drawing.Point(6, 14);
            this.PreviewPictureBox.Name = "PreviewPictureBox";
            this.PreviewPictureBox.Size = new System.Drawing.Size(75, 67);
            this.PreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PreviewPictureBox.TabIndex = 0;
            this.PreviewPictureBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.InterfacesTreeView);
            this.groupBox3.Location = new System.Drawing.Point(12, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(285, 124);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Available Interfaces";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Update interval";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(164, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "ms";
            // 
            // ReceiveColorEditButton
            // 
            this.ReceiveColorEditButton.Location = new System.Drawing.Point(149, 41);
            this.ReceiveColorEditButton.Name = "ReceiveColorEditButton";
            this.ReceiveColorEditButton.Size = new System.Drawing.Size(55, 23);
            this.ReceiveColorEditButton.TabIndex = 27;
            this.ReceiveColorEditButton.Text = "Edit";
            this.ReceiveColorEditButton.UseVisualStyleBackColor = true;
            this.ReceiveColorEditButton.Click += new System.EventHandler(this.ReceiveColorEditButton_Click);
            // 
            // InterfaceCheckTimer
            // 
            this.InterfaceCheckTimer.Enabled = true;
            this.InterfaceCheckTimer.Interval = 5000;
            this.InterfaceCheckTimer.Tick += new System.EventHandler(this.InterfaceCheckTimer_OnTick);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(143, 307);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 29;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(224, 307);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 30;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // UpdateIntervalNumericUpDown
            // 
            this.UpdateIntervalNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.UpdateIntervalNumericUpDown.Location = new System.Drawing.Point(96, 16);
            this.UpdateIntervalNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.UpdateIntervalNumericUpDown.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.UpdateIntervalNumericUpDown.Name = "UpdateIntervalNumericUpDown";
            this.UpdateIntervalNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.UpdateIntervalNumericUpDown.TabIndex = 33;
            this.UpdateIntervalNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // SendColorEditButton
            // 
            this.SendColorEditButton.Location = new System.Drawing.Point(149, 67);
            this.SendColorEditButton.Name = "SendColorEditButton";
            this.SendColorEditButton.Size = new System.Drawing.Size(55, 23);
            this.SendColorEditButton.TabIndex = 34;
            this.SendColorEditButton.Text = "Edit";
            this.SendColorEditButton.UseVisualStyleBackColor = true;
            this.SendColorEditButton.Click += new System.EventHandler(this.SendColorEditButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LinearRadioButton);
            this.groupBox1.Controls.Add(this.LogarithmicRadioButton);
            this.groupBox1.Controls.Add(this.MaxGraphYValueNumericUpDown);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 72);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graph scale";
            // 
            // LinearRadioButton
            // 
            this.LinearRadioButton.AutoSize = true;
            this.LinearRadioButton.Location = new System.Drawing.Point(13, 21);
            this.LinearRadioButton.Name = "LinearRadioButton";
            this.LinearRadioButton.Size = new System.Drawing.Size(54, 17);
            this.LinearRadioButton.TabIndex = 28;
            this.LinearRadioButton.TabStop = true;
            this.LinearRadioButton.Text = "Linear";
            this.LinearRadioButton.UseVisualStyleBackColor = true;
            // 
            // LogarithmicRadioButton
            // 
            this.LogarithmicRadioButton.AutoSize = true;
            this.LogarithmicRadioButton.Location = new System.Drawing.Point(13, 42);
            this.LogarithmicRadioButton.Name = "LogarithmicRadioButton";
            this.LogarithmicRadioButton.Size = new System.Drawing.Size(79, 17);
            this.LogarithmicRadioButton.TabIndex = 27;
            this.LogarithmicRadioButton.TabStop = true;
            this.LogarithmicRadioButton.Text = "Logarithmic";
            this.LogarithmicRadioButton.UseVisualStyleBackColor = true;
            // 
            // MaxGraphYValueNumericUpDown
            // 
            this.MaxGraphYValueNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.MaxGraphYValueNumericUpDown.Location = new System.Drawing.Point(179, 19);
            this.MaxGraphYValueNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.MaxGraphYValueNumericUpDown.Name = "MaxGraphYValueNumericUpDown";
            this.MaxGraphYValueNumericUpDown.Size = new System.Drawing.Size(59, 20);
            this.MaxGraphYValueNumericUpDown.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "KB/s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Max Y value";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 338);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SendColorEditButton);
            this.Controls.Add(this.UpdateIntervalNumericUpDown);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.ReceiveColorEditButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SendColorTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReceiveColorTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "NetworkTrayGraph v1.0 - Settings";
            this.NotifyIconContextMenuStrip.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxGraphYValueNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon GraphNotifyIcon;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.TextBox ReceiveColorTextBox;
        private System.Windows.Forms.TreeView InterfacesTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SendColorTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox PreviewPictureBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ReceiveColorEditButton;
        private System.Windows.Forms.Timer InterfaceCheckTimer;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.NumericUpDown UpdateIntervalNumericUpDown;
        private System.Windows.Forms.Button SendColorEditButton;
        private System.Windows.Forms.ColorDialog ColorPickerDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton LinearRadioButton;
        private System.Windows.Forms.RadioButton LogarithmicRadioButton;
        private System.Windows.Forms.NumericUpDown MaxGraphYValueNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

