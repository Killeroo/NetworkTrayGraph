
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
            this.InterfacesTreeView = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.InterfaceCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.UpdateIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ColorPickerDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LinearRadioButton = new System.Windows.Forms.RadioButton();
            this.LogarithmicRadioButton = new System.Windows.Forms.RadioButton();
            this.MaxGraphYValueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TooltipTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ReceivedHighlightColorEditButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ReceivedHighlightColorTextBox = new System.Windows.Forms.TextBox();
            this.ReceivedBodyColorEditButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ReceivedBodyColorTextBox = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.SentHighlightColorEditButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.SentHighlightColorTextBox = new System.Windows.Forms.TextBox();
            this.SentBodyColorEditButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.SentBodyColorTextBox = new System.Windows.Forms.TextBox();
            this.NotifyIconContextMenuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxGraphYValueNumericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.NotifyIconContextMenuStrip.Size = new System.Drawing.Size(197, 104);
            // 
            // TitleToolStripMenuItem
            // 
            this.TitleToolStripMenuItem.Enabled = false;
            this.TitleToolStripMenuItem.Name = "TitleToolStripMenuItem";
            this.TitleToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.TitleToolStripMenuItem.Text = "NetworkTrayGraph v1.3";
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
            // InterfacesTreeView
            // 
            this.InterfacesTreeView.CheckBoxes = true;
            this.InterfacesTreeView.Location = new System.Drawing.Point(6, 14);
            this.InterfacesTreeView.Name = "InterfacesTreeView";
            this.InterfacesTreeView.Size = new System.Drawing.Size(279, 99);
            this.InterfacesTreeView.TabIndex = 7;
            this.InterfacesTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.InterfacesTreeView_AfterCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PreviewPictureBox);
            this.groupBox2.Location = new System.Drawing.Point(212, 38);
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
            this.groupBox3.Location = new System.Drawing.Point(8, 289);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(291, 124);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Available Interfaces";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Update interval";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(185, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "ms";
            this.label8.Visible = false;
            // 
            // InterfaceCheckTimer
            // 
            this.InterfaceCheckTimer.Interval = 5000;
            this.InterfaceCheckTimer.Tick += new System.EventHandler(this.InterfaceCheckTimer_OnTick);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(137, 420);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 29;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(218, 420);
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
            this.UpdateIntervalNumericUpDown.Location = new System.Drawing.Point(101, 12);
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
            this.UpdateIntervalNumericUpDown.Size = new System.Drawing.Size(78, 20);
            this.UpdateIntervalNumericUpDown.TabIndex = 33;
            this.UpdateIntervalNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpdateIntervalNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.UpdateIntervalNumericUpDown.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LinearRadioButton);
            this.groupBox1.Controls.Add(this.LogarithmicRadioButton);
            this.groupBox1.Controls.Add(this.MaxGraphYValueNumericUpDown);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(8, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 72);
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
            this.LogarithmicRadioButton.CheckedChanged += new System.EventHandler(this.LogarithmicRadioButton_CheckedChanged);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TooltipTextBox);
            this.groupBox4.Location = new System.Drawing.Point(212, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(87, 69);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            // 
            // TooltipTextBox
            // 
            this.TooltipTextBox.Location = new System.Drawing.Point(6, 13);
            this.TooltipTextBox.Multiline = true;
            this.TooltipTextBox.Name = "TooltipTextBox";
            this.TooltipTextBox.ReadOnly = true;
            this.TooltipTextBox.Size = new System.Drawing.Size(75, 49);
            this.TooltipTextBox.TabIndex = 0;
            this.TooltipTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ReceivedHighlightColorEditButton);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.ReceivedHighlightColorTextBox);
            this.groupBox5.Controls.Add(this.ReceivedBodyColorEditButton);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.ReceivedBodyColorTextBox);
            this.groupBox5.Location = new System.Drawing.Point(8, 38);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(192, 78);
            this.groupBox5.TabIndex = 43;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Receive Colors";
            // 
            // ReceivedHighlightColorEditButton
            // 
            this.ReceivedHighlightColorEditButton.Location = new System.Drawing.Point(131, 48);
            this.ReceivedHighlightColorEditButton.Name = "ReceivedHighlightColorEditButton";
            this.ReceivedHighlightColorEditButton.Size = new System.Drawing.Size(55, 20);
            this.ReceivedHighlightColorEditButton.TabIndex = 33;
            this.ReceivedHighlightColorEditButton.Text = "Edit";
            this.ReceivedHighlightColorEditButton.UseVisualStyleBackColor = true;
            this.ReceivedHighlightColorEditButton.Click += new System.EventHandler(this.ReceivedHighlightColorEditButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Highlight";
            // 
            // ReceivedHighlightColorTextBox
            // 
            this.ReceivedHighlightColorTextBox.Enabled = false;
            this.ReceivedHighlightColorTextBox.Location = new System.Drawing.Point(54, 48);
            this.ReceivedHighlightColorTextBox.Name = "ReceivedHighlightColorTextBox";
            this.ReceivedHighlightColorTextBox.Size = new System.Drawing.Size(71, 20);
            this.ReceivedHighlightColorTextBox.TabIndex = 31;
            // 
            // ReceivedBodyColorEditButton
            // 
            this.ReceivedBodyColorEditButton.Location = new System.Drawing.Point(131, 19);
            this.ReceivedBodyColorEditButton.Name = "ReceivedBodyColorEditButton";
            this.ReceivedBodyColorEditButton.Size = new System.Drawing.Size(55, 20);
            this.ReceivedBodyColorEditButton.TabIndex = 30;
            this.ReceivedBodyColorEditButton.Text = "Edit";
            this.ReceivedBodyColorEditButton.UseVisualStyleBackColor = true;
            this.ReceivedBodyColorEditButton.Click += new System.EventHandler(this.ReceivedBodyColorEditButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Body";
            // 
            // ReceivedBodyColorTextBox
            // 
            this.ReceivedBodyColorTextBox.Enabled = false;
            this.ReceivedBodyColorTextBox.Location = new System.Drawing.Point(54, 19);
            this.ReceivedBodyColorTextBox.Name = "ReceivedBodyColorTextBox";
            this.ReceivedBodyColorTextBox.Size = new System.Drawing.Size(71, 20);
            this.ReceivedBodyColorTextBox.TabIndex = 28;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.SentHighlightColorEditButton);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.SentHighlightColorTextBox);
            this.groupBox6.Controls.Add(this.SentBodyColorEditButton);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.SentBodyColorTextBox);
            this.groupBox6.Location = new System.Drawing.Point(8, 122);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(192, 83);
            this.groupBox6.TabIndex = 44;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sent Colors";
            // 
            // SentHighlightColorEditButton
            // 
            this.SentHighlightColorEditButton.Location = new System.Drawing.Point(131, 52);
            this.SentHighlightColorEditButton.Name = "SentHighlightColorEditButton";
            this.SentHighlightColorEditButton.Size = new System.Drawing.Size(55, 20);
            this.SentHighlightColorEditButton.TabIndex = 33;
            this.SentHighlightColorEditButton.Text = "Edit";
            this.SentHighlightColorEditButton.UseVisualStyleBackColor = true;
            this.SentHighlightColorEditButton.Click += new System.EventHandler(this.SentHighlightColorEditButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Highlight";
            // 
            // SentHighlightColorTextBox
            // 
            this.SentHighlightColorTextBox.Enabled = false;
            this.SentHighlightColorTextBox.Location = new System.Drawing.Point(54, 52);
            this.SentHighlightColorTextBox.Name = "SentHighlightColorTextBox";
            this.SentHighlightColorTextBox.Size = new System.Drawing.Size(71, 20);
            this.SentHighlightColorTextBox.TabIndex = 31;
            // 
            // SentBodyColorEditButton
            // 
            this.SentBodyColorEditButton.Location = new System.Drawing.Point(131, 23);
            this.SentBodyColorEditButton.Name = "SentBodyColorEditButton";
            this.SentBodyColorEditButton.Size = new System.Drawing.Size(55, 20);
            this.SentBodyColorEditButton.TabIndex = 30;
            this.SentBodyColorEditButton.Text = "Edit";
            this.SentBodyColorEditButton.UseVisualStyleBackColor = true;
            this.SentBodyColorEditButton.Click += new System.EventHandler(this.SentBodyColorEditButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Body";
            // 
            // SentBodyColorTextBox
            // 
            this.SentBodyColorTextBox.Enabled = false;
            this.SentBodyColorTextBox.Location = new System.Drawing.Point(54, 23);
            this.SentBodyColorTextBox.Name = "SentBodyColorTextBox";
            this.SentBodyColorTextBox.Size = new System.Drawing.Size(71, 20);
            this.SentBodyColorTextBox.TabIndex = 28;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 455);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UpdateIntervalNumericUpDown);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "NetworkTrayGraph v1.3 - Settings";
            this.TopMost = true;
            this.NotifyIconContextMenuStrip.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UpdateIntervalNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxGraphYValueNumericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.TreeView InterfacesTreeView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox PreviewPictureBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer InterfaceCheckTimer;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.NumericUpDown UpdateIntervalNumericUpDown;
        private System.Windows.Forms.ColorDialog ColorPickerDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton LinearRadioButton;
        private System.Windows.Forms.RadioButton LogarithmicRadioButton;
        private System.Windows.Forms.NumericUpDown MaxGraphYValueNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TooltipTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button ReceivedHighlightColorEditButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ReceivedHighlightColorTextBox;
        private System.Windows.Forms.Button ReceivedBodyColorEditButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox ReceivedBodyColorTextBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button SentHighlightColorEditButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox SentHighlightColorTextBox;
        private System.Windows.Forms.Button SentBodyColorEditButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox SentBodyColorTextBox;
    }
}

