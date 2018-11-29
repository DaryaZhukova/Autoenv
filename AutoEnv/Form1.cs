﻿using System;
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
            var list = new List<string>();
            LookupChecks(iisfichtree.Nodes, list);
            fich.iisfeatures = list;
            string output;
            do
                output = fich.InstallIIS();
            while (!output.Contains("100"));
            Outputbox.Text = String.Format("IIS features: {0} succesfully installed", String.Join(", ", fich.iisfeatures).Replace("/FeatureName:", ""));
        }
        private void Iisbutton_Click(object sender, EventArgs e)
        {
            
            if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\InetStp", "VersionString", null) == null)
            {
                Outputbox.Text = "IIS is installing...";
                fich.InstallIIS();
                Outputbox.Text = String.Format("IIS {0} succesfully installed", fich.GetIISversion());
            }
            else
                Outputbox.Text = String.Format("IIS {0} already installed in your system, click <IIS configure> to check configuration", fich.GetIISversion());
        }
        private void IISconf_Click(object sender, EventArgs e)
        {
            Outputbox.Text = "Checking configuration...";
            
            fich.iisfeatures = fich.GetIISfeature();
            if (fich.iisfeatures.Count == 0)
            {
                Outputbox.Text = String.Format("IIS {0} properly configured", fich.GetIISversion());
            }
            fich.InstallIIS();
            Outputbox.Text = String.Format("IIS features: {0} succesfully installed", String.Join(", ", fich.iisfeatures).Replace("/FeatureName:", ""));
        }
        private void iisfichtree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Outputbox.Text = e.Node.Name;
        }
        private void iisfichtree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool is_checked = e.Node.Checked;
            foreach (TreeNode child in e.Node.Nodes)
                child.Checked = is_checked;
        }
        private void advbtn_Click(object sender, EventArgs e)
        {
            iisfichtree.Visible = !iisfichtree.Visible;
            if (!iisfichtree.Nodes.ContainsKey("Internet Information Services"))
            {
                TreeNode IISroot = new TreeNode("Internet Information Services")
                {
                    Name = "IISroot"
                };
                iisfichtree.Nodes.Add(IISroot);
                foreach (KeyValuePair<string, string> keyValue in fich.allfeatures[0])
                {
                    TreeNode newnode = new TreeNode(keyValue.Value)
                    {
                        Name = keyValue.Key
                    };
                    iisfichtree.Nodes[0].Nodes.Add(newnode);
                }
                foreach (KeyValuePair<string, string> keyValue in fich.allfeatures[1])
                {
                    TreeNode newnode = new TreeNode(keyValue.Value)
                    {
                        Name = keyValue.Key
                    };
                    iisfichtree.Nodes[0].Nodes[0].Nodes.Add(newnode);
                }
                foreach (KeyValuePair<string, string> keyValue in fich.allfeatures[2])
                {
                    TreeNode newnode = new TreeNode(keyValue.Value)
                    {
                        Name = keyValue.Key
                    };
                    iisfichtree.Nodes[0].Nodes[1].Nodes.Add(newnode);
                }
                foreach (KeyValuePair<string, string> keyValue in fich.allfeatures[3])
                {
                    TreeNode newnode = new TreeNode(keyValue.Value)
                    {
                        Name = keyValue.Key
                    };
                    iisfichtree.Nodes[0].Nodes[0].Nodes[0].Nodes.Add(newnode);
                }
                foreach (KeyValuePair<string, string> keyValue in fich.allfeatures[4])
                {
                    TreeNode newnode = new TreeNode(keyValue.Value)
                    {
                        Name = keyValue.Key
                    };
                    iisfichtree.Nodes[0].Nodes[1].Nodes[0].Nodes.Add(newnode);
                }
                foreach (KeyValuePair<string, string> keyValue in fich.allfeatures[5])
                {
                    TreeNode newnode = new TreeNode(keyValue.Value)
                    {
                        Name = keyValue.Key
                    };
                    iisfichtree.Nodes[0].Nodes[1].Nodes[1].Nodes.Add(newnode);
                }
                foreach (KeyValuePair<string, string> keyValue in fich.allfeatures[6])
                {
                    TreeNode newnode = new TreeNode(keyValue.Value)
                    {
                        Name = keyValue.Key
                    };
                    iisfichtree.Nodes[0].Nodes[1].Nodes[2].Nodes.Add(newnode);
                }
                foreach (KeyValuePair<string, string> keyValue in fich.allfeatures[7])
                {
                    TreeNode newnode = new TreeNode(keyValue.Value)
                    {
                        Name = keyValue.Key
                    };
                    iisfichtree.Nodes[0].Nodes[1].Nodes[3].Nodes.Add(newnode);
                }
                foreach (KeyValuePair<string, string> keyValue in fich.allfeatures[8])
                {
                    TreeNode newnode = new TreeNode(keyValue.Value)
                    {
                        Name = keyValue.Key
                    };
                    iisfichtree.Nodes[0].Nodes[1].Nodes[4].Nodes.Add(newnode);
                }
                if (fich.osversion == "Win7")
                {
                    foreach (KeyValuePair<string, string> keyValue in fich.allfeatures[9])
                    {
                        TreeNode newnode = new TreeNode(keyValue.Value)
                        {
                            Name = keyValue.Key
                        };
                        iisfichtree.Nodes[0].Nodes[1].Nodes[1].Nodes[4].Nodes.Add(newnode);
                    }
                }
                CheckRecomended(iisfichtree.Nodes);
            }
        }
        public void CheckRecomended(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (fich.iisfeatures.Contains("/FeatureName:" + node.Name)) 
                {
                    node.Checked = true;
                }
                CheckRecomended(node.Nodes);
            }
        }
        public List<string> LookupChecks(TreeNodeCollection nodes, List<string> list)
        {
             List<string> headerlist = new List<string> {"IISWMT", "IISRoot", "IISWWWS"};
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && !headerlist.Contains(node.Name))
                { 
                    list.Add("/FeatureName:" + node.Name);
                }
                LookupChecks(node.Nodes, list);
            }
            return list;
        }
    }
    public class Installfeatures
    {
        private readonly Version ver = new Version(6, 2);
        public string osversion;
        public int osbit;
        public List<string> iisfeatures;
        public List<Dictionary<string, string>> allfeatures;
        public Installfeatures()
        {
            if (Environment.Is64BitOperatingSystem == true)
                osbit = 64;
            else
                osbit = 32;
            if (Environment.OSVersion.Version < ver)
            {
                osversion = "Win7";
                iisfeatures = new List<string>(new string[9] {
                            "/FeatureName:IIS-WebServerRole",
                            "/FeatureName:IIS-WebServerManagementTools",
                            "/FeatureName:IIS-Metabase",
                            "/FeatureName:IIS-ManagementConsole",
                            "/FeatureName:IIS-NetFxExtensibility",
                            "/FeatureName:IIS-ASPNET",
                            "/FeatureName:IIS-ISAPIExtensions",
                            "/FeatureName:IIS-ISAPIFilter",
                            "/FeatureName:IIS-RequestMonitor"
                         });
                allfeatures = new List<Dictionary<string, string>>
                {
                    new Dictionary<string, string>
                    {
                        ["IISWMT"] = "Web Management Tools",
                        ["IISWWWS"] = "World Wide Web Services"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-IIS6ManagementCompatibility"] = "IIS 6 Management Compatibility",
                        ["IIS-ManagementConsole"] = "IIS Management Console",
                        ["IIS-ManagementScriptingTools"] = "IIS Management Scripts and Tools",
                        ["IIS-ManagementService"] = "IIS Management Service"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-ApplicationDevelopment"] = "Application Development Features",
                        ["IIS-CommonHttpFeatures"] = "Common HTTP Features",
                        ["IIS-HealthAndDiagnostics"] = "Health And Diagnostics",
                        ["IIS-Perfomance_Features"] = "Perfomance Features",
                        ["IIS-Security"] = "Security"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-LegacySnapIn"] = "IIS 6 Management Console",
                        ["IIS-LegacyScripts"] = "IIS 6 Scripting Tools",
                        ["IIS-WMICompatibility"] = "IIS 6 WMI Compatibility",
                        ["IIS-Metabase"] = "IIS Metabase and IIS 6 Configuration Compatibility"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-NetFxExtensibility"] = ".NET Extensibility",
                        ["IIS-ASP"] = "ASP",
                        ["IIS-ASPNET"] = "ASP.NET",
                        ["IIS-CGI"] = "CGI",
                        ["IIS-ISAPIExtensions"] = "ISAPI Extensions",
                        ["IIS-ISAPIFilter"] = "ISAPI Filter",
                        ["IIS-ServerSideIncludes"] = "Server-Side Includes"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-DefaultDocument"] = "Default Document",
                        ["IIS-DirectoryBrowsing"] = "Directory Browsing",
                        ["IIS-HttpErrors"] = "HTTP Errors",
                        ["IIS-HttpRedirect"] = "HTTP Redirection",
                        ["IIS-StaticContent"] = "Static Content",
                        ["IIS-WebDAV"] = "WebDAV Publishing"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-CustomLogging"] = "Custom Logging",
                        ["IIS-HttpLogging"] = "HTTP Logging",
                        ["IIS-LoggingLibraries"] = "Logging Tools",
                        ["IIS-ODBCLogging"] = "ODBC Logging",
                        ["IIS-RequestMonitor"] = "Request Monitor",
                        ["IIS-HttpTracing"] = "Tracing"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-HttpCompressionDynamic"] = "Dynamic Content Compression",
                        ["IIS-HttpCompressionStatic"] = "Static Content Compression"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-BasicAuthentication"] = "Basic Authentication",
                        ["IIS-ClientCertificateMappingAuthentication"] = "Client Certificate Mapping Authentication",
                        ["IIS-DigestAuthentication"] = "Digest Authentication",
                        ["IIS-IISCertificateMappingAuthentication"] = "IIS Client Certificate Mapping Authentication",
                        ["IIS-IPSecurity"] = "IP Security",
                        ["IIS-RequestFiltering"] = "Request Filtering",
                        ["IIS-URLAuthorization"] = "URL Authorization",
                        ["IIS-WindowsAuthentication"] = "Windows Authentication"
                    },
                                        new Dictionary<string, string>
                    {
                        ["ManagementOdata"] = "OData Services for Management IIS Extention"
                    }
                };
            }
            else
            {
                osversion = "Win10";
                iisfeatures = new List<string>(new string[11] {
                            "/FeatureName:IIS-WebServerRole",
                            "/FeatureName:IIS-WebServerManagementTools",
                            "/FeatureName:IIS-Metabase",
                            "/FeatureName:IIS-ManagementConsole",
                            "/FeatureName:IIS-NetFxExtensibility",
                            "/FeatureName:IIS-NetFxExtensibility45",
                            "/FeatureName:IIS-ASPNET",
                            "/FeatureName:IIS-ASPNET45",
                            "/FeatureName:IIS-ISAPIExtensions",
                            "/FeatureName:IIS-ISAPIFilter",
                            "/FeatureName:IIS-RequestMonitor"
                         });
                allfeatures = new List<Dictionary<string, string>>
                {
                    new Dictionary<string, string>
                    {
                        ["IISWMT"] = "Web Management Tools",
                        ["IISWWWS"] = "World Wide Web Services"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-IIS6ManagementCompatibility"] = "IIS 6 Management Compatibility",
                        ["IIS-ManagementConsole"] = "IIS Management Console",
                        ["IIS-ManagementScriptingTools"] = "IIS Management Scripts and Tools",
                        ["IIS-ManagementService"] = "IIS Management Service"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-ApplicationDevelopment"] = "Application Development Features",
                        ["IIS-CommonHttpFeatures"] = "Common HTTP Features",
                        ["IIS-HealthAndDiagnostics"] = "Health And Diagnostics",
                        ["IIS-Perfomance_Features"] = "Perfomance Features",
                        ["IIS-Security"] = "Security"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-LegacySnapIn"] = "IIS 6 Management Console",
                        ["IIS-LegacyScripts"] = "IIS 6 Scripting Tools",
                        ["IIS-WMICompatibility"] = "IIS 6 WMI Compatibility",
                        ["IIS-Metabase"] = "IIS Metabase and IIS 6 Configuration Compatibility"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-NetFxExtensibility"] = ".NET Extensibility 3.5",
                        ["IIS-NetFxExtensibility45"] = ".NET Extensibility 4.7",
                        ["IIS-ApplicationInit"] = "Application Initialization",
                        ["IIS-ASP"] = "ASP",
                        ["IIS-ASPNET"] = "ASP.NET 3.5",
                        ["IIS-ASPNET45"] = "ASP.NET 4.7",
                        ["IIS-CGI"] = "CGI",
                        ["IIS-ISAPIExtensions"] = "ISAPI Extensions",
                        ["IIS-ISAPIFilter"] = "ISAPI Filter",
                        ["IIS-ServerSideIncludes"] = "Server-Side Includes",
                        ["IIS-WebSockets"] = "WebSocket Protocol"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-DefaultDocument"] = "Default Document",
                        ["IIS-DirectoryBrowsing"] = "Directory Browsing",
                        ["IIS-HttpErrors"] = "HTTP Errors",
                        ["IIS-HttpRedirect"] = "HTTP Redirection",
                        ["IIS-StaticContent"] = "Static Content",
                        ["IIS-WebDAV"] = "WebDAV Publishing"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-CustomLogging"] = "Custom Logging",
                        ["IIS-HttpLogging"] = "HTTP Logging",
                        ["IIS-LoggingLibraries"] = "Logging Tools",
                        ["IIS-ODBCLogging"] = "ODBC Logging",
                        ["IIS-RequestMonitor"] = "Request Monitor",
                        ["IIS-HttpTracing"] = "Tracing"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-HttpCompressionDynamic"] = "Dynamic Content Compression",
                        ["IIS-HttpCompressionStatic"] = "Static Content Compression"
                    },
                    new Dictionary<string, string>
                    {
                        ["IIS-BasicAuthentication"] = "Basic Authentication",
                        ["IIS-CertProvider"] = "Centralized SSL Certificate Support",
                        ["IIS-ClientCertificateMappingAuthentication"] = "Client Certificate Mapping Authentication",
                        ["IIS-DigestAuthentication"] = "Digest Authentication",
                        ["IIS-IISCertificateMappingAuthentication"] = "IIS Client Certificate Mapping Authentication",
                        ["IIS-IPSecurity"] = "IP Security",
                        ["IIS-RequestFiltering"] = "Request Filtering",
                        ["IIS-URLAuthorization"] = "URL Authorization",
                        ["IIS-WindowsAuthentication"] = "Windows Authentication"
                    }
                };
            }
        }

        public string InstallIIS()
        {
            //int exitcode;
            Process RunIIS = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c DISM /online /enable-feature " + String.Join(" ", iisfeatures),
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true
                 }
            };
            string line = "";
            string errline = "";
            List<string> addfeatures = new List<string>();
            RunIIS.Start();
            while (!RunIIS.StandardOutput.EndOfStream)
            {
                errline = line;
                line = RunIIS.StandardOutput.ReadLine();
                if (errline.Contains("diagnostics."))
                {
                    addfeatures = line.Replace(" ", "").Split(',').ToList<string>();
                }
            }
            RunIIS.Close();
            addfeatures = addfeatures.Select(s => "/FeatureName:" + s).ToList();
            iisfeatures.AddRange(addfeatures);
            return errline;
            
        }
        public string GetIISversion()
        {
            string version = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\InetStp", "VersionString", "nosuch").ToString();
            return version;
        }
        public List<string> GetIISfeature()
        {
            string line;
            var disabledfeathres = new Stack<string>();
            Process RunIIS = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c DISM /online /get-featureinfo " + String.Join(" ", iisfeatures),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
             };
            RunIIS.Start();
            while (!RunIIS.StandardOutput.EndOfStream)
            {
                line = RunIIS.StandardOutput.ReadLine();
                if (line.Contains("Feature Name"))
                    disabledfeathres.Push("/FeatureName:" + line.Split(':')[1].Trim());
                if (line.Contains("State : Enabled"))
                    disabledfeathres.Pop();
            }
            return disabledfeathres.ToList();
        }

    }
}
