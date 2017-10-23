using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using MySystem;
using Microsoft.Win32;

namespace CAP_Agent
{
    public partial class Form1 : Form
    {
        NotifyIcon CA2AgentIcon;
        Icon CapIcon;
        //Thread CA2AgentWorker;
        bool CloseSwitch = false;

        

        public Form1()
        {
            InitializeComponent();
            //MyInfo myInfo = new MyInfo();

            HostIP.Text = MyInfo.HostIP;
            HostName.Text = MyInfo.HostName;
            HostOS.Text = MyInfo.OS;
            CoreCount.Text = MyInfo.CPUCores.ToString();
            UserDomain.Text = MyInfo.UserDomain;
            UserName.Text = MyInfo.UserName;
            //dns.Text = Dns.GetHostAddresses("apps.capsonic.com")[0].ToString();
            MS_Office.Items.AddRange(MyInfo.Office.ToArray());
            ServiceTag.Text = MyInfo.SerciveTag;
            PCModel.Text = MyInfo.Model;
            //MS_Office.Items.Add(getMyOffice());

            #region Context Menu Admin
            //Create Capsonic Agent Context Manu and Load Menu Items
            ContextMenu contextMenu = new ContextMenu();
            //Menu Items
            MenuItem TittleMenuItem = new MenuItem("Capsonic IT Agent");
            MenuItem quitMenuItem = new MenuItem("Quit");
            MenuItem ConfigureMenuItem = new MenuItem("Configure");
            //Adding Menu Items
            contextMenu.MenuItems.Add(TittleMenuItem);
            contextMenu.MenuItems.Add(ConfigureMenuItem);


            //Quit
            contextMenu.MenuItems.Add(quitMenuItem);

            //Wire Up Click Events to Context MAnu Items
            quitMenuItem.Click += quitMenuItem_Click;
            ConfigureMenuItem.Click += configureMenuItem_Click;

            #endregion

            //Configure Capsonic Agent Notify Tray Icon
            CapIcon = new Icon("CA2.ico");
            CA2AgentIcon = new NotifyIcon();
            CA2AgentIcon.Icon = CapIcon;
            CA2AgentIcon.Visible = true;
            CA2AgentIcon.ContextMenu = contextMenu;

            //Hide Main Form
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void configureMenuItem_Click(object sender, EventArgs e)
        {
            //Hide Main Form
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = false;
            
        }

        private void quitMenuItem_Click(object sender, EventArgs e)
        {
            CA2AgentIcon.Dispose();
            CloseSwitch = true;
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!CloseSwitch)
            {
                base.OnFormClosing(e);

                if (e.CloseReason == CloseReason.WindowsShutDown)
                {
                    quitMenuItem_Click(null, null);
                }
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
        }

        private List<string> getMyOffice()
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            List<string> office = new List<string>();

            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                var test = rk.GetSubKeyNames();
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");
                            var size = sk.GetValue("EstimatedSize");

                            ListViewItem item; 
                            if (displayName != null && (displayName.ToString().Contains("Microsoft Office")))
                            {
                                office.Add(displayName.ToString());
                                //if (size != null)
                                //    item = new ListViewItem(new string[] {displayName.ToString(),
                                //                       size.ToString()});
                                //else
                                //    item = new ListViewItem(new string[] { displayName.ToString() });
                                //lstDisplayHardware.Items.Add(item);
                            }
                        }
                        catch (Exception ex)
                        {
                            //return "Not Found";

                        }
                    }
                }

                return office;
                //label1.Text += " (" + lstDisplayHardware.Items.Count.ToString() + ")";
            }
        }

    }
}
