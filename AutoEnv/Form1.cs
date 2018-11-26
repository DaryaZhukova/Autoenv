using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
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
        }
        private void Iisbutton_Click(object sender, EventArgs e)
        {
            Installfeatures fich = new Installfeatures();
            if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\InetStp", "VersionString", null) == null)
            {
                Outputbox.Text = "IIS is installing...";
                if (fich.InstallIIS() == 0)
                    Outputbox.Text = String.Format("IIS {0} succesfully installed", fich.GetIISversion());
            }
            else
                Outputbox.Text = String.Format("IIS {0} already installed in your system, click <IIS configure> to check configuration", fich.GetIISversion());
        }

        private void IISconf_Click(object sender, EventArgs e)
        {
            Outputbox.Text = "Checking configuration...";
            Installfeatures fich = new Installfeatures();
            fich.iisfeatures = fich.GetIISfeature();
            if (fich.iisfeatures.Length == 0)
            {
                Outputbox.Text = String.Format("IIS {0} properly configured", fich.GetIISversion());
            }
            else if (fich.InstallIIS() == 0)
                Outputbox.Text = String.Format("IIS features: {0} succesfully installed", String.Join(", ", fich.iisfeatures).Replace("/FeatureName:", ""));
        }
    }
    public class Installfeatures
    {
        private readonly Version ver = new Version(6, 2);
        public string osversion;
        public string runuser;
        public string[] iisfeatures;
        public Installfeatures()
        {
            if (System.Environment.OSVersion.Version < ver)
            {
                osversion = "Win7";
                runuser = "";
                iisfeatures = new string[8] {
                            "/FeatureName:IIS-WebServerRole",
                            "/FeatureName:IIS-WebServerManagementTools",
                            "/FeatureName:IIS-IIS6ManagementCompatibility",
                            "/FeatureName:IIS-NetFxExtensibility",
                            "/FeatureName:IIS-ASPNET",
                            "/FeatureName:IIS-ISAPIExtensions",
                            "/FeatureName:IIS-ISAPIFilter",
                            "/FeatureName:IIS-RequestMonitor"
                         };
            }
            else
            {
                osversion = "Win10";
                runuser = "runas";
                iisfeatures = new string[10] {
                            "/FeatureName:IIS-WebServerRole",
                            "/FeatureName:IIS-WebServerManagementTools",
                            "/FeatureName:IIS-IIS6ManagementCompatibility",
                            "/FeatureName:IIS-NetFxExtensibility",
                            "/FeatureName:IIS-NetFxExtensibility45",
                            "/FeatureName:IIS-ASPNET",
                            "/FeatureName:IIS-ASPNET45",
                            "/FeatureName:IIS-ISAPIExtensions",
                            "/FeatureName:IIS-ISAPIFilter",
                            "/FeatureName:IIS-RequestMonitor"
                         };
            }
        }

        public int InstallIIS()
        {

            Process RunIIS = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    //RunIIS.StartInfo.Arguments = "/c DISM /online /enable-feature /featurename:TFTP";
                    Arguments = "/c DISM /online /enable-feature " + String.Join(" ", iisfeatures),
                    UseShellExecute = false,
                    CreateNoWindow = true

                }
            };
            RunIIS.Start();
            RunIIS.WaitForExit();
            return RunIIS.ExitCode;
        }
        public string GetIISversion()
        {
            string version = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\InetStp", "VersionString", "nosuch").ToString();
            return version;
        }
        public string[] GetIISfeature()
        {
            Process RunIIS = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    //Verb = "runas",
                    FileName = "cmd.exe",
                    Arguments = "/c DISM /online /get-featureinfo " + String.Join(" ", iisfeatures),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
             };
            string line;
            var disabledfeathres = new Stack<string>();
            RunIIS.Start();
            while (!RunIIS.StandardOutput.EndOfStream)
            {
                line = RunIIS.StandardOutput.ReadLine();
                if (line.Contains("Feature Name"))
                    disabledfeathres.Push("/FeatureName:" + line.Split(':')[1].Trim());
                if (line.Contains("State : Enabled"))
                    disabledfeathres.Pop();
            }

            return disabledfeathres.ToArray();
        }
    }
}
