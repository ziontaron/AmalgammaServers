using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            int Port = 11000;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];

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

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, Port);


            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);


            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                
                while (true)
                {
                    Console.WriteLine("Server IP: " + localIP);
                    Console.WriteLine("Server Port: " + Port);
                    Console.WriteLine("Waiting for a connection...");

                    Socket handler = listener.Accept();
                    Console.WriteLine(handler.AddressFamily.ToString()+" - "+ "connected");
                    //Console.WriteLine("connected");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("error");
            }
        }
    }
}
