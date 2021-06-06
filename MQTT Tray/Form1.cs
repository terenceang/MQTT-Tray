using System;
using System.Text;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.ManagedClient;
using System.Management;
using System.Text.RegularExpressions;
using System.Drawing;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;

namespace MQTT_Tray
{

    public partial class Form1 : Form
    {
        bool configured = false;

        IManagedMqttClient mqttClient = new MqttFactory().CreateManagedMqttClient();

        public Form1()
        {
            InitializeComponent();
        }

        /// Returns MAC Address from first Network Card in Computer
        /// </summary>
        /// <returns>[string] MAC Address</returns>
        public static string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)  // only return MAC Address from first card
                {
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }
            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        //exit from Menu
        private async void exitToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            if (Chk_ACshutdown.Checked)
            {
                PowerOffAsync();
            }
            Application.Exit();
        }

        //power on from Menu
        public async void airconPowerToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            if (airconPowerToolStripMenuItem.Checked)
            {
                PowerOffAsync();
            }
            else
            {
                PowerOnAsync();
            }
        }

        private bool Load_Setting()
        {
            {
                //Default Port = 1883
                if (Properties.Settings.Default.MQTT_Port != "")
                {
                    TB_Port.Text = Properties.Settings.Default.MQTT_Port;
                }

                TB_User.Text = Properties.Settings.Default.MQTT_User;
                TB_Password.Text = Properties.Settings.Default.MQTT_Password;

                Chk_ACBoot.Checked = Properties.Settings.Default.ACBoot;
                Chk_ACshutdown.Checked = Properties.Settings.Default.ACShutdown;

                ck1_startup.Checked = Properties.Settings.Default.Startup;

                /*                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                                if (!ck1_startup.Checked)
                                {
                                   // registryKey.SetValue("MQTT_Tray", Application.ExecutablePath);
                                }
                                else
                                {
                                   // registryKey.DeleteValue("MQTT_Tray",false);
                                }

                                registryKey.Close();*/

                //Validate

                //Check IP

                bool config = true;
                if (Properties.Settings.Default.DeviceID != "")
                {
                    TB_DevID.BackColor = DefaultBackColor;
                    TB_DevID.Text = Properties.Settings.Default.DeviceID;
                }
                else
                {
                    config = false;
                    TB_DevID.BackColor = Color.Red;
                }

                if (Properties.Settings.Default.MQTT_Ipaddr != "")
                {
                    TB_IPaddr.Text = Properties.Settings.Default.MQTT_Ipaddr;

                    Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                    MatchCollection result = ip.Matches(TB_IPaddr.Text);
                    if (!result[0].Success)
                    {
                        config = false;
                    }
                }

                if (Properties.Settings.Default.MQTT_User == "")
                {
                    TB_User.BackColor = Color.Red;
                    config = false;
                }
                else
                {
                    TB_User.BackColor = DefaultBackColor;
                }

                if (Properties.Settings.Default.MQTT_Password == "")
                {
                    TB_Password.BackColor = Color.Red;
                    config = false;
                }
                else
                {
                    TB_Password.BackColor = DefaultBackColor;
                }
                return config;
            }
        }

        //settings
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_Setting();
            Show();
        }

        private async void PowerOnAsync()
        {
            airconPowerToolStripMenuItem.Checked = true;
            notifyIcon1.Icon = Properties.Resources.PowerOn;
#if DEBUG
            Console.WriteLine("Power On");
#else
            await mqttClient.PublishAsync(new MqttApplicationMessageBuilder().WithTopic("cmnd/" + TB_DevID.Text + "/mode").WithPayload("cool").Build());
#endif
        }

        private async void PowerOffAsync()
        {
            airconPowerToolStripMenuItem.Checked = false;
            notifyIcon1.Icon = Properties.Resources.PowerOff;
#if DEBUG
            Console.WriteLine("Power Off");
#else
            await mqttClient.PublishAsync(new MqttApplicationMessageBuilder().WithTopic("cmnd/" + TB_DevID.Text + "/mode").WithPayload("off").Build());
#endif
        }


        private async void Form1_ShownAsync(object sender, EventArgs e)
        {
            Console.WriteLine("### START ###");

            if (!Load_Setting())
            {
                Show();
            }
            else
            {
                configured = true;
                Hide();
            }

            if (configured)
            {
                string MQTT_ClientID = String.Concat("PC-", GetMACAddress());

                string MQTT_IPaddr = Properties.Settings.Default.MQTT_Ipaddr;
                string MQTT_User = Properties.Settings.Default.MQTT_User;
                string MQTT_Password = Properties.Settings.Default.MQTT_Password;

                // Setup and start a managed MQTT client.
                ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                    .WithClientOptions(new MqttClientOptionsBuilder()
                        .WithClientId(MQTT_ClientID)
                        .WithTcpServer(MQTT_IPaddr)
                        .WithCredentials(MQTT_User, MQTT_Password)
                        .WithCleanSession(true)
                        .WithKeepAlivePeriod(TimeSpan.FromSeconds(120)).Build())
                    .Build();

                await mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic("tele/" + TB_DevID.Text + "/#").Build());
                await mqttClient.StartAsync(options);

                if (Chk_ACBoot.Checked)
                {
                    PowerOnAsync();
                }

                //MQTT Event Handlers

                mqttClient.Connected += (s, ev) =>
                {
                    Console.WriteLine("### Connected ###");
                    notifyIcon1.Icon = Properties.Resources.PowerOn;
                    notifyIcon1.Text = "Connected";
                };

                mqttClient.Disconnected += (s, ev) =>
                {
                    Console.WriteLine("### Disconnected ###");
                    notifyIcon1.Icon = Properties.Resources.PowerDisconnect;
                    notifyIcon1.Text = "Disconnected";
                };

                //             
                mqttClient.ApplicationMessageReceived += (s, ev) =>
                {

#if DEBUG
                    string json_string = "{'model':0,'power':0,'mode':'off','temp':23,'fan':'auto','vSwing':15,'hSwing':13,'quiet':0,'powerful':0,'clock':0,'onTimer':0,'offTimer':0}";
                    dynamic Payload = JsonConvert.DeserializeObject(json_string); 

                     Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                     Console.WriteLine($"+ Topic = {ev.ApplicationMessage.Topic}");
                     Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(ev.ApplicationMessage.Payload)}");
                     Console.WriteLine($"+ QoS = {ev.ApplicationMessage.QualityOfServiceLevel}");
                     Console.WriteLine($"+ Retain = {ev.ApplicationMessage.Retain}");
                     Console.WriteLine();

#else
                    dynamic Payload = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(ev.ApplicationMessage.Payload));
#endif
                    if (Payload.power == "1")
                    {
                        notifyIcon1.Icon = Properties.Resources.PowerOn;
                    }
                    else
                    {
                        notifyIcon1.Icon = Properties.Resources.PowerOff;
                    }
                };

            }
        }


        //Buttons Events

        private async void BTN_Save_Settings_ClickAsync(object sender, EventArgs e)
        {
            Properties.Settings.Default.MQTT_Ipaddr = TB_IPaddr.Text;
            Properties.Settings.Default.MQTT_Port = TB_Port.Text;
            Properties.Settings.Default.MQTT_User = TB_User.Text;
            Properties.Settings.Default.DeviceID = TB_DevID.Text;
            Properties.Settings.Default.MQTT_Password = TB_Password.Text;
            Properties.Settings.Default.ACBoot = Chk_ACBoot.Checked;
            Properties.Settings.Default.ACShutdown = Chk_ACshutdown.Checked;
            Properties.Settings.Default.Startup = ck1_startup.Checked;
            Properties.Settings.Default.Save();

            if (Load_Setting())
            {
                //reload credential
                await mqttClient.StopAsync();

                string MQTT_ClientID = String.Concat("PC-", GetMACAddress());
                string MQTT_IPaddr = Properties.Settings.Default.MQTT_Ipaddr;
                string MQTT_User = Properties.Settings.Default.MQTT_User;
                string MQTT_Password = Properties.Settings.Default.MQTT_Password;

                // Setup and start a managed MQTT client.
                ManagedMqttClientOptions options = new ManagedMqttClientOptionsBuilder()
                    .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                    .WithClientOptions(new MqttClientOptionsBuilder()
                        .WithClientId(MQTT_ClientID)
                        .WithTcpServer(MQTT_IPaddr)
                        .WithCredentials(MQTT_User, MQTT_Password)
                        .WithCleanSession(true)
                        .WithKeepAlivePeriod(TimeSpan.FromSeconds(120)).Build())
                    .Build();

                await mqttClient.StartAsync(options);
                Hide();
            }
            else
            {
                Form2 testDialog = new Form2();
                testDialog.ShowDialog();
            }
        }

        private void BTN_Cancel_Settings_Click(object sender, EventArgs e)
        {
            if (Load_Setting())
            {
                Hide();
            }
            else
            {
                Application.Exit();
            }
        }


        //mouse click toggle
        private async void notifyIcon1_MouseClickAsync(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (airconPowerToolStripMenuItem.Checked)
                {
                    PowerOffAsync();
                }
                else
                {
                    PowerOnAsync();
                }
            }

        }

        //shutdown 
        private async void Form1_FormClosedAsync(object sender, FormClosedEventArgs e)
        {
            if (Chk_ACshutdown.Checked)
            {
                PowerOffAsync();
            }
        }


        private void ck1_startup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Startup = ck1_startup.Checked;
            Properties.Settings.Default.Save();

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string startmenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu) + "\\Programs\\MQTT Tray\\MQTT Tray.appref-ms";

            if (ck1_startup.Checked)
            {
                // if (registryKey.GetValue("MQTT_Tray") == null) registryKey.SetValue("MQTT_Tray", Application.ExecutablePath);
                // C: \Users\teren\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\MQTT Tray
                registryKey.SetValue("MQTT_Tray", startmenu);
            }
            else
            {
                registryKey.DeleteValue("MQTT_Tray", false);
            }
        }

    }
}
