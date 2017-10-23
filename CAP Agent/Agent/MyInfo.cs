using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Win32;
using System.Management;

namespace MySystemInfo
{
    public static class MyInfo
    {
        public static string HostName
        {
            get { return Environment.MachineName; }
        }
        public static string HostIP
        {
            get
            {
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }
                return localIP;
            }
        }
        public static string OS
        {
            get
            {
                //return Environment.OSVersion.ToString();

                return Environment.OSVersion.ToString();
            }
        }
        public static int CPUCores
        {
            get
            {
                return Environment.ProcessorCount;
            }
        }
        public static string UserDomain
        {
            get
            {
                return Environment.UserDomainName;
            }
        }
        public static string UserName
        {
            get
            {
                return Environment.UserName;
            }
        }
        public static List<string> Office
        {
            get
            {
                return getMyOffice();
            }
        }
        public static string ServiceTag
        {
            get
            {
                return getMyServiceTag();
            }

        }
        public static string Model
        {
            get
            {
                return getMyModel();
            }

        }

        private static List<string> getMyOffice()
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            List<string> office = new List<string>();

            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");
                            var size = sk.GetValue("EstimatedSize");
                            ;
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
        private static string getMyServiceTag()
        {
            string servicetag = "UNKNOWN";

            ManagementClass wmi = new ManagementClass("Win32_Bios");
            foreach (ManagementObject bios in wmi.GetInstances())
            {
                servicetag = bios.Properties["Serialnumber"].Value.ToString().Trim();
            }

            return servicetag;
        }
        private static string getMyModel()
        {
            string Model = "UNKNOWN";

            string ComputerName = "localhost";
            ManagementScope Scope;
            Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
            Scope.Connect();
            ObjectQuery Query = new ObjectQuery("SELECT * FROM Win32_ComputerSystemProduct");
            ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);

            foreach (ManagementObject WmiObject in Searcher.Get())
            {
                Model = WmiObject["Name"].ToString();
                // Console.WriteLine("{0,-35} {1,-40}", "Model", WmiObject["Name"]);// String                     
            }

            return Model;
        }
        private static bool CheckIfExists(string ST)
        {
            string query = "SELECT * FROM AssetList WHERE (ServiceTag = N'"+ ST + "')";
            Data_Base_MNG.SQL DBMG_SQL = new Data_Base_MNG.SQL("RSSERVER", "ASSETS_INV", "sa", "6rzq4d1");

            string x = DBMG_SQL.Execute_Scalar(query);
            if (x == "")
            {
                return false;
            }
            return true;
        }
        private static bool Enroll()
        {
            string query = "INSERT INTO [AssetList] "+
           "([ServiceTag],[HostName],[HostIP],[OS],[OfficeVer],[UpdatedDate],[UserName],[AssetModel]) VALUES" +
           "('"+ ServiceTag + "','"+ HostName + "','"+ HostIP + "','"+OS+"','"+ getMyOffice()[0]+
           "',Getdate(),'"+ UserName + "','"+ Model + "')";

            Data_Base_MNG.SQL DBMG_SQL = new Data_Base_MNG.SQL("192.168.0.11", "ASSETS_INV", "sa", "6rzq4d1");

            if (!DBMG_SQL.Execute_Command(query))
            {
                string x = DBMG_SQL.Error_Mjs;
                return false;
            }

            return true;

        }
        private static bool UpdateInfo()
        {
            string query = "UPDATE [ASSETS_INV].[dbo].[AssetList] " +
   " SET [ServiceTag] = '" + ServiceTag + "'" +
    "  ,[HostName] = '" + HostName + "'" +
     " ,[HostIP] = '" + HostIP + "'" +
     " ,[OS] = '" + OS + "'" +
     " ,[OfficeVer] = '" + Office[0] + "'" +
     " ,[UpdatedDate] = Getdate()" +
     " ,[UserName] = '" + UserName + "'" +
     " ,[AssetModel] = '" + Model + "'" +
  " WHERE (ServiceTag= '" + ServiceTag + "')";

            Data_Base_MNG.SQL DBMG_SQL = new Data_Base_MNG.SQL("192.168.0.11", "ASSETS_INV", "sa", "6rzq4d1");
            if (!DBMG_SQL.Execute_Command(query))
            {
                string x = DBMG_SQL.Error_Mjs;
                return false;
            }

            return true;
        }

        public static bool DoMyThing()
        {
            if (CheckIfExists(ServiceTag))
            {
                UpdateInfo();
                return true;
            }
            else
            {
                Enroll();
                return false;
            }              
        }
    }
}
