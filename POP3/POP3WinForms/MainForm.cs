using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace POP3WinForms
{
    public partial class MainForm : Form
    {
        private Socket socket;
        private List<Email> emailList;

        public MainForm()
        {
            InitializeComponent();
            this.emailView.SelectionChanged += EmailView_SelectionChanged;
        }

        private void EmailView_SelectionChanged(object sender, EventArgs e)
        {
            int x = emailView.SelectedRows[0].Index;
            emailText.Text = emailList[emailView.SelectedRows[0].Index].Text;
        }

        private void LogInPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if ((socket = LogIn("s1610650", passTextBox.Text)) != null)
            {
                logInPanel.Visible = false;
                EmailPanel.Visible = true;
                emailList = GetEmailList(socket);
                SetEmailTable(emailList);
            }
        }

        private Socket LogIn(string user, string pass)
        {
            String ip = "193.219.80.134";
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint VUMail = new IPEndPoint(ipAddress, 110);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(VUMail);
                if (GetResponse(socket).StartsWith("-ERR"))
                    return null;
                socket.Send(Encoding.UTF8.GetBytes("User " + user + "\r\n"));
                string s = GetResponse(socket);
                if (s.StartsWith("-ERR"))
                {
                    socket.Send(Encoding.UTF8.GetBytes("QUIT\r\n"));
                    //socket.Receive(bytes);
                    return null;
                }

                socket.Send(Encoding.UTF8.GetBytes("Pass " + pass + "\r\n"));
                s = GetResponse(socket);
                if (s.StartsWith("-ERR"))
                {
                    socket.Send(Encoding.UTF8.GetBytes("QUIT\r\n"));
                    //socket.Receive(bytes);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }

            return socket;

        }

        private List<Email> GetEmailList(Socket socket)
        {
            try
            {
                socket.Send(Encoding.UTF8.GetBytes("STAT\r\n"));
                string response = GetResponse(socket);
                if (response.StartsWith("-ERR"))
                    return null;
                int emails = int.Parse(Regex.Match(response, @"\d+").Value);
                List<Email> list = new List<Email>();
                //for (int i = 1; i <= emails; i++)
                for (int i = 265; i <= emails; i++)
                {
                    socket.Send(Encoding.UTF8.GetBytes("RETR " + i + "\r\n"));
                    Email email = new Email { Text = GetMultiLineResponse(socket), Nr = i };
                    email.Sender = Regex.Match(email.Text, "^Sender:.*", RegexOptions.Multiline).Value;
                    list.Add(email);
                }
                list.Sort();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        private void SetEmailTable(List<Email> list)
        {
            list.ForEach(email => emailView.Rows.Add(null, email.Sender));
        }

        private string GetMultiLineResponse(Socket socket)
        {
            byte[] bytes = new byte[512];
            int buffSize;
            String result = String.Empty;
            do
            {
                buffSize = socket.Receive(bytes);
                result += Encoding.UTF8.GetString(bytes, 0, buffSize);
            } while (!result.EndsWith("\r\n.\r\n"));
            return result;
        }

        private string GetResponse(Socket socket)
        {
            byte[] bytes = new byte[512];
            int buffSize;
            buffSize = socket.Receive(bytes);
            return Encoding.UTF8.GetString(bytes, 0, buffSize);
        }

        private static void PrintNumberOfReceivedBytes(Socket socket)
        {
            byte[] bytes = new byte[512];
            int buffSize, totalReceived = 0;
            string result = String.Empty;
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
