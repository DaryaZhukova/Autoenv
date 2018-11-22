using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoEnv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Iisvbutton_Click(object sender, EventArgs e)
        {
            if (GetIISversion() == "noSuch")
                Outputbox.Text = "IIS is not installed in the system";
            else
                Outputbox.Text = GetIISversion();
        }
        private void Iisbutton_Click(object sender, EventArgs e)
        {
            if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\InetStp", "VersionString", null) == null)
            {
                if (InstallIIS() == 0) 
                    Outputbox.Text = "IIS succesfully installed";
            }
            else
            {
                if (GetIISversion() == "noSuch")
                    Outputbox.Text = "IIS is not installed in the system";
                else
                    Outputbox.Text = GetIISversion();
            }

        }

        private int InstallIIS()
        {
            System.Diagnostics.Process RunIIS = new System.Diagnostics.Process();
            //RunIIS.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            RunIIS.StartInfo.FileName = "cmd.exe";
            RunIIS.StartInfo.Arguments = "/c DISM /online /enable-feature /featurename:TFTP";
            RunIIS.StartInfo.Verb = "runas";
            RunIIS.Start();
            RunIIS.WaitForExit();
            int result = RunIIS.ExitCode;
            return result;
        }
        private string GetIISversion()
        {
            string version = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\InetStp", "VersionString", "noSuch").ToString();
            return version;
        }
    }
}
