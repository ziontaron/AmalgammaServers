using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //"192.168.0.154"
                //IPHostEntry ipHostInfo = Dns.GetHostAddresses("192.168.0.154");
                IPHostEntry ipHostInfo = Dns.Resolve("59.178.131.180");
                //IPAddress ipAddress = ipHostInfo.AddressList[0];

                IPAddress ipAddress = IPAddress.Parse("192.168.0.154");

                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);


                Socket sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);


                try
                {
                    sender.Connect(remoteEP);
                    //sender.
                    Console.WriteLine("Socket connected <strong class=\"highlight\">to</strong> {0}",
                        sender.RemoteEndPoint.ToString());
                    Console.WriteLine("End");

                    
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    Console.Read();
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                    Console.Read();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    Console.Read();
                }

            }
            catch
            { Console.WriteLine("could not <strong class=\"highlight\">connect</strong> A"); }

        }
    }
}
