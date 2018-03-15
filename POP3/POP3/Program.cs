using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace POP3
{
    class Program
    {

        static void Main(string[] args)
        {
            string pass = ConfigurationManager.AppSettings["Pass"];
            byte[] bytes = new byte[512];
            int buffSize = 0;
            String ip = "193.219.80.134";
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint VUMail = new IPEndPoint(ipAddress, 110);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(VUMail);
                Console.WriteLine("Socket connected to {0}", socket.RemoteEndPoint.ToString());
                PrintReceivedBytes(socket);

                socket.Send(Encoding.ASCII.GetBytes("User s1610650\r\n"));
                PrintReceivedBytes(socket);

                socket.Send(Encoding.ASCII.GetBytes("Pass " + pass + "\r\n"));
                PrintReceivedBytes(socket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }finally
            {
                socket.Send(Encoding.ASCII.GetBytes("QUIT\r\n"));
                buffSize = socket.Receive(bytes);
                Console.Write(Encoding.ASCII.GetString(bytes, 0, buffSize));
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            Console.ReadKey();
        }

        private static void PrintReceivedBytes(Socket socket)
        {
            byte[] bytes = new byte[512];
            int buffSize = socket.Receive(bytes);
            Console.Write(Encoding.ASCII.GetString(bytes, 0, buffSize));
        }
    }
}
