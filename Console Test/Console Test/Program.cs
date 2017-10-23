using System;
using System.Collections.Generic;
using System.Management;
using System.Text;
using MySystemInfo;

namespace CAP_AGENT
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(MyInfo.Office);
                Console.WriteLine(MyInfo.OS);
                Console.WriteLine(MyInfo.Model);
                Console.WriteLine(MyInfo.HostIP);
                Console.WriteLine(MyInfo.HostName);
                Console.WriteLine(MyInfo.UserName);
                Console.WriteLine(MyInfo.CPUCores);
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Exception {0} Trace {1}", e.Message, e.StackTrace));
            }
            Console.WriteLine("Press Enter to exit");
            Console.Read();
        }
    }
}