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
using System.IO;

namespace Guldkortet
{
    public partial class Form1 : Form
    {
        TcpListener listener;
        TcpClient client;
        const int PORT = 12345;

        string messageFromClient, userInfo, cardInfo;
        const string FILE_PATH_CARDS = @"C:\Users\Viktoriya\source\repos\Guldkortet\material\Material\Guldkortet\kortlista.txt";
        const string FILE_PATH_USERS = @"C:\Users\Viktoriya\source\repos\Guldkortet\material\Material\Guldkortet\kundlista.txt";

        List<Card> cards = new List<Card>();

        public Form1()
        {
            InitializeComponent();
        }

        public async void StartReception()
        {
            try
            {
                client = await listener.AcceptTcpClientAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, Text); }

            btnStart.BackColor = Color.Turquoise;

            StartReading(client);
        }

        public async void StartReading(TcpClient client)
        {
            byte[] buffer = new byte[20];

            int start = 0;
            try
            {
                start = await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, Text); }

            messageFromClient = Encoding.Unicode.GetString(buffer, 0, start);
            txbTextKontroll.AppendText(messageFromClient); // DELETE LATER

            StartReading(client);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, PORT);
                listener.Start();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            StartReception();
        }

        // DELETE LATER
        private void btnStartaKlient_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Viktoriya\source\repos\Guldkortet\material\Material\Guldkortet\NOS_Export.exe");
        }

        public async void Dekonsktruering()
        {
            string[] messageArray = messageFromClient.Split(new string[] { "-" }, StringSplitOptions.None);
            txbTextKontroll.Clear();
            foreach (string message in messageArray) // CHECK; DELETE LATER
            {
                txbTextKontroll.AppendText(message + "  ");
            }

            userInfo = messageArray[0];
            cardInfo = messageArray[1];
        }

        public List<string> FileLoad(string filePath)
        {
            List<string> fileLoad = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(filePath, Encoding.UTF8, true);
                using (sr)
                {
                    string item = "";
                    while ((item = sr.ReadLine()) != null)
                    {
                        fileLoad.Add(item);
                    }
                }
                return fileLoad;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, Text);
                return null;
            }
        }

        public void FileSave(List<string> fileLoad)
        {
            List<string[]> importedList = new List<string[]>();
            for (int i = 0; i < fileLoad.Count; i++)
            {
                string[] array = fileLoad[i].Split(new string[] { "###" }, StringSplitOptions.None);
                importedList.Add(array);
            }
            
            // method that converts data inside to usable and addable to the card class
        }

        private void btnDekonstruering_Click(object sender, EventArgs e)
        {
            Dekonsktruering();
        }
    }
}
