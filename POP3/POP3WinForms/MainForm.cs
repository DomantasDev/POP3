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
        private int currentPage = 1;
        private int emailCount;
        public MainForm()
        {
            emailList = new List<Email>();
            InitializeComponent();
            this.emailView.SelectionChanged += EmailView_SelectionChanged;
        }

        private void EmailView_SelectionChanged(object sender, EventArgs e)
        {
            if (emailView.SelectedRows.Count > 0)
            {
                int index = emailView.SelectedRows[0].Index;
                if (emailList[index].Text == null)
                {
                    socket.Send(Encoding.UTF8.GetBytes("RETR " + emailList[index].Nr + "\r\n"));
                    string s = GetMultiLineResponse(socket);
                    s = s.Substring(s.IndexOf(@"text/"));
                    emailList[index].Text = s.Substring(s.IndexOf("\r\n\r\n"));
                }
                emailText.Text = emailList[index].Text;
            }
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if ((socket = LogIn(userTextBox.Text, passTextBox.Text)) != null)
            {
                logInPanel.Visible = false;
                EmailPanel.Visible = true;
                GetEmailCount(socket, out emailCount);
                GetEmailList(socket, emailList);
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
                    GetResponse(socket);
                    return null;
                }

                socket.Send(Encoding.UTF8.GetBytes("Pass " + pass + "\r\n"));
                s = GetResponse(socket);
                if (s.StartsWith("-ERR"))
                {
                    socket.Send(Encoding.UTF8.GetBytes("QUIT\r\n"));
                    GetResponse(socket);
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

        private Boolean GetEmailCount(Socket socket, out int emailCount)
        {
            socket.Send(Encoding.UTF8.GetBytes("STAT\r\n"));
            string response = GetResponse(socket);
            if (response.StartsWith("-ERR"))
            {
                emailCount = 0;
                return false;
            }
            emailCount = int.Parse(Regex.Match(response, @"\d+").Value);
            return true;
        }

        private void GetEmailList(Socket socket, List<Email> list)
        {
            try
            {
                if(list.Count <= (currentPage - 1) * 10)             
                    for(int i = emailCount - (currentPage - 1) * 10; i > emailCount - currentPage * 10; i--)
                    {
                        socket.Send(Encoding.UTF8.GetBytes("TOP " + i + " 0\r\n"));
                        Email email = new Email { Nr = i };
                        string s = Regex.Match(GetMultiLineResponse(socket), "^Sender:.*", RegexOptions.Multiline).Value;
                        if(!s.Equals(String.Empty))
                            s = s.Substring(s.IndexOf(":") + 1);
                        email.Sender = s;
                        list.Add(email);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void SetEmailTable(List<Email> list)
        {
            emailView.Rows.Clear();
            emailView.Refresh();
            for (int i = (currentPage - 1) * 10 ; i < currentPage * 10 && i < emailList.Count(); i++)
            {
                emailView.Rows.Add(false, emailList[i].Sender);
            }
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            socket.Send(Encoding.UTF8.GetBytes("QUIT\r\n"));
            if (GetResponse(socket).StartsWith("+OK"))
                this.Close();          
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                GetEmailList(socket, emailList);
                SetEmailTable(emailList);
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
                currentPage++;
                GetEmailList(socket, emailList);
                SetEmailTable(emailList);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 10; i++)
            {
                if ((bool)emailView.Rows[i].Cells[0].Value)
                {
                    socket.Send(Encoding.UTF8.GetBytes("DELE " + (emailCount - i - (currentPage - 1) * 10)+ "\r\n"));
                    string s = GetResponse(socket);
                }
            }
        }
    }
}
