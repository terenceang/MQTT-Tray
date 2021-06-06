using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MQTT_Tray
{
    static class Program
    {
        static Mutex mutex = new Mutex(false, "MQTT_Tray");
        //System Tray code.
        [STAThread]
        static void Main()
        {

            // if you like to wait a few seconds in case that the instance is just 
            // shutting down
            if (!mutex.WaitOne(TimeSpan.FromSeconds(2), false))
            {
                MessageBox.Show("MQTT Tray already running", "", MessageBoxButtons.OK);
                return;
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            finally { mutex.ReleaseMutex(); } // I find this more explicit
        }
    }
}
