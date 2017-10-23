using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySystemInfo;

namespace Agent
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
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

                MyInfo.DoMyThing();

            }
            catch (Exception e)
            {
                //Console.WriteLine(String.Format("Exception {0} Trace {1}", e.Message, e.StackTrace));
            }
            //Console.WriteLine("Press Enter to exit");
            //Console.Read();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
