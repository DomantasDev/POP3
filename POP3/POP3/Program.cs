using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.RegularExpressions;

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

                socket.Send(Encoding.UTF8.GetBytes("User s1610650\r\n"));
                PrintReceivedBytes(socket);

                socket.Send(Encoding.UTF8.GetBytes("Pass " + pass + "\r\n"));
                PrintReceivedBytes(socket);

                socket.Send(Encoding.UTF8.GetBytes("Stat\r\n"));
                PrintReceivedBytes(socket);

                socket.Send(Encoding.UTF8.GetBytes("List\r\n"));
                PrintReceivedBytes(socket);
                int x = 267;
                socket.Send(Encoding.UTF8.GetBytes("Retr " + x + "\r\n"));
                PrintNumberOfReceivedBytes(socket);

                socket.Send(Encoding.UTF8.GetBytes("Top " + x + " 0\r\n"));
                PrintMultiLine(socket);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                for (int i = 0; i < 100; i++)
                    Console.WriteLine("WELl SHIEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEET");
            }finally
            {
                socket.Send(Encoding.UTF8.GetBytes("QUIT\r\n"));
                buffSize = socket.Receive(bytes);
                Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, buffSize));
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                Console.WriteLine("THE END");
            }

            Console.ReadKey();
        }

        private static void PrintReceivedBytes(Socket socket)
        {
            byte[] bytes = new byte[512];
            int buffSize;          
            do {
                buffSize = socket.Receive(bytes);
                Console.Write(Encoding.UTF8.GetString(bytes, 0, buffSize));
            } while (buffSize == 512);
        }

        private static void PrintMultiLine(Socket socket)
        {
            byte[] bytes = new byte[512];
            int buffSize;
            string s;
            do
            {
                buffSize = socket.Receive(bytes);
                s = Encoding.UTF8.GetString(bytes, 0, buffSize);
                Console.Write(s);
            } while (!s.EndsWith("\r\n.\r\n"));
        }

        private static void PrintNumberOfReceivedBytes(Socket socket)
        {
            byte[] bytes = new byte[512];
            int buffSize, totalReceived = 0;

            buffSize = socket.Receive(bytes);
            totalReceived += buffSize;
            int bytesToReceive = int.Parse(Regex.Match(Encoding.UTF8.GetString(bytes, 0, buffSize), @"\d+").Value);
            Console.Write(Encoding.UTF8.GetString(bytes, 0, buffSize));

            while (totalReceived < bytesToReceive)
            {
                buffSize = socket.Receive(bytes);
                totalReceived += buffSize;
                Console.Write(Encoding.UTF8.GetString(bytes, 0, buffSize));
            } 
            Console.WriteLine("\nGauta baitu :" + totalReceived);
        }
    }
}
