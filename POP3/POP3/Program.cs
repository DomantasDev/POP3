using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace POP3
{
    class Program
    {

        static void Main(string[] args)
        {
            String ip = "193.219.80.134";
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 110);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(remoteEP);
                Console.WriteLine("Socket connected to {0}", socket.RemoteEndPoint.ToString());

                byte[] bytes = new byte[512];
                int x = socket.Receive(bytes);
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, x));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }finally
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            Console.ReadKey();
        }
    }
}
