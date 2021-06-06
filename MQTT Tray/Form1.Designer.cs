namespace MQTT_Tray
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.airconPowerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.BTN_Save_Settings = new System.Windows.Forms.Button();
            this.BTN_Cancel_Settings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_IPaddr = new System.Windows.Forms.TextBox();
            this.TB_Port = new System.Windows.Forms.TextBox();
            this.TB_User = new System.Windows.Forms.TextBox();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.Chk_ACBoot = new System.Windows.Forms.CheckBox();
            this.Chk_ACshutdown = new System.Windows.Forms.CheckBox();
            this.TB_DevID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ck1_startup = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.airconPowerToolStripMenuItem,
            this.fanToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 132);
            // 
            // airconPowerToolStripMenuItem
            // 
            this.airconPowerToolStripMenuItem.Checked = true;
            this.airconPowerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.airconPowerToolStripMenuItem.Name = "airconPowerToolStripMenuItem";
            this.airconPowerToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            this.airconPowerToolStripMenuItem.Text = "Aircon";
            this.airconPowerToolStripMenuItem.Visible = false;
            this.airconPowerToolStripMenuItem.Click += new System.EventHandler(this.airconPowerToolStripMenuItem_ClickAsync);
            // 
            // fanToolStripMenuItem
            // 
            this.fanToolStripMenuItem.Name = "fanToolStripMenuItem";
            this.fanToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            this.fanToolStripMenuItem.Text = "Fan";
            this.fanToolStripMenuItem.Visible = false;
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            this.settingToolStripMenuItem.Text = "Settings";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 32);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_ClickAsync);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Remote";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClickAsync);
            // 
            // BTN_Save_Settings
            // 
            this.BTN_Save_Settings.Location = new System.Drawing.Point(144, 342);
            this.BTN_Save_Settings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Save_Settings.Name = "BTN_Save_Settings";
            this.BTN_Save_Settings.Size = new System.Drawing.Size(112, 35);
            this.BTN_Save_Settings.TabIndex = 1;
            this.BTN_Save_Settings.Text = "Ok";
            this.BTN_Save_Settings.UseVisualStyleBackColor = true;
            this.BTN_Save_Settings.Click += new System.EventHandler(this.BTN_Save_Settings_ClickAsync);
            // 
            // BTN_Cancel_Settings
            // 
            this.BTN_Cancel_Settings.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Cancel_Settings.Location = new System.Drawing.Point(20, 342);
            this.BTN_Cancel_Settings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Cancel_Settings.Name = "BTN_Cancel_Settings";
            this.BTN_Cancel_Settings.Size = new System.Drawing.Size(112, 35);
            this.BTN_Cancel_Settings.TabIndex = 2;
            this.BTN_Cancel_Settings.Text = "Cancel";
            this.BTN_Cancel_Settings.UseVisualStyleBackColor = true;
            this.BTN_Cancel_Settings.Click += new System.EventHandler(this.BTN_Cancel_Settings_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 138);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password";
            // 
            // TB_IPaddr
            // 
            this.TB_IPaddr.Location = new System.Drawing.Point(104, 14);
            this.TB_IPaddr.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_IPaddr.Name = "TB_IPaddr";
            this.TB_IPaddr.Size = new System.Drawing.Size(148, 26);
            this.TB_IPaddr.TabIndex = 6;
            this.TB_IPaddr.Text = "192.168.1.100";
            // 
            // TB_Port
            // 
            this.TB_Port.Location = new System.Drawing.Point(104, 54);
            this.TB_Port.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Port.MaximumSize = new System.Drawing.Size(148, 20);
            this.TB_Port.MinimumSize = new System.Drawing.Size(148, 20);
            this.TB_Port.Name = "TB_Port";
            this.TB_Port.Size = new System.Drawing.Size(148, 26);
            this.TB_Port.TabIndex = 7;
            this.TB_Port.Text = "1883";
            // 
            // TB_User
            // 
            this.TB_User.Location = new System.Drawing.Point(104, 94);
            this.TB_User.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_User.Name = "TB_User";
            this.TB_User.Size = new System.Drawing.Size(148, 26);
            this.TB_User.TabIndex = 8;
            // 
            // TB_Password
            // 
            this.TB_Password.Location = new System.Drawing.Point(104, 134);
            this.TB_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.PasswordChar = '*';
            this.TB_Password.Size = new System.Drawing.Size(148, 26);
            this.TB_Password.TabIndex = 9;
            // 
            // Chk_ACBoot
            // 
            this.Chk_ACBoot.AutoSize = true;
            this.Chk_ACBoot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Chk_ACBoot.Location = new System.Drawing.Point(8, 221);
            this.Chk_ACBoot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Chk_ACBoot.Name = "Chk_ACBoot";
            this.Chk_ACBoot.Size = new System.Drawing.Size(179, 24);
            this.Chk_ACBoot.TabIndex = 10;
            this.Chk_ACBoot.Text = "Turn on AC on Boot ";
            this.Chk_ACBoot.UseVisualStyleBackColor = true;
            // 
            // Chk_ACshutdown
            // 
            this.Chk_ACshutdown.AutoSize = true;
            this.Chk_ACshutdown.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Chk_ACshutdown.Location = new System.Drawing.Point(9, 256);
            this.Chk_ACshutdown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Chk_ACshutdown.Name = "Chk_ACshutdown";
            this.Chk_ACshutdown.Size = new System.Drawing.Size(214, 24);
            this.Chk_ACshutdown.TabIndex = 11;
            this.Chk_ACshutdown.Text = "Turn off AC on Shutdown";
            this.Chk_ACshutdown.UseVisualStyleBackColor = true;
            // 
            // TB_DevID
            // 
            this.TB_DevID.Location = new System.Drawing.Point(104, 174);
            this.TB_DevID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_DevID.Name = "TB_DevID";
            this.TB_DevID.Size = new System.Drawing.Size(148, 26);
            this.TB_DevID.TabIndex = 13;
            this.TB_DevID.Text = "AcRemote_10ba65";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 178);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Device-ID";
            // 
            // ck1_startup
            // 
            this.ck1_startup.AutoSize = true;
            this.ck1_startup.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ck1_startup.Location = new System.Drawing.Point(8, 296);
            this.ck1_startup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ck1_startup.Name = "ck1_startup";
            this.ck1_startup.Size = new System.Drawing.Size(148, 24);
            this.ck1_startup.TabIndex = 14;
            this.ck1_startup.Text = "Run on Start up";
            this.ck1_startup.UseVisualStyleBackColor = true;
            this.ck1_startup.CheckedChanged += new System.EventHandler(this.ck1_startup_CheckedChanged);
            // 
            // Form1
            // 
            this.AcceptButton = this.BTN_Save_Settings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_Cancel_Settings;
            this.ClientSize = new System.Drawing.Size(267, 375);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.ck1_startup);
            this.Controls.Add(this.TB_DevID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Chk_ACshutdown);
            this.Controls.Add(this.Chk_ACBoot);
            this.Controls.Add(this.TB_Password);
            this.Controls.Add(this.TB_User);
            this.Controls.Add(this.TB_Port);
            this.Controls.Add(this.TB_IPaddr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTN_Cancel_Settings);
            this.Controls.Add(this.BTN_Save_Settings);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(289, 431);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(289, 431);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Remote Control Setting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosedAsync);
            this.Shown += new System.EventHandler(this.Form1_ShownAsync);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem airconPowerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button BTN_Save_Settings;
        private System.Windows.Forms.Button BTN_Cancel_Settings;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_IPaddr;
        private System.Windows.Forms.TextBox TB_Port;
        private System.Windows.Forms.TextBox TB_User;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.CheckBox Chk_ACBoot;
        private System.Windows.Forms.CheckBox Chk_ACshutdown;
        private System.Windows.Forms.TextBox TB_DevID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ck1_startup;
    }
}

