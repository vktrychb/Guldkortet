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
using System.Text.RegularExpressions;

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
        List<string[]> users = new List<string[]>();
        List<string> blockedUsers = new List<string>();

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
            byte[] buffer = new byte[40];

            int start = 0;
            try
            {
                start = await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, Text); return; }

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

        private void btnStartaKlient_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Viktoriya\source\repos\Guldkortet\material\Material\Guldkortet\NOS_Export.exe");
        }  // DELETE LATER

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
        }  // done

        public List<string[]> FileSave(List<string> fileLoad)
        {
            List<string[]> importedList = new List<string[]>();
            for (int i = 0; i < fileLoad.Count; i++)
            {
                string[] array = fileLoad[i].Split(new string[] { "###" }, StringSplitOptions.None);
                importedList.Add(array);
            }

            return importedList;
            
            // method that converts data inside to usable and addable to the card class
        }

        public void StoreData(List<string[]> saveList)
        {
            List<string> cardList = new List<string>();
            List<string> userList = new List<string>();

            foreach (string[] array in saveList)
            {
                cardList.Add(array[1]);
                userList.Add(array[0]);
            }
        }  // ??? needed?

        public void StoreUserData(List<string[]> l)
        {
            users = l;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listener.Stop();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnFileLoad_Click(object sender, EventArgs e)
        {
            FileSave(FileLoad(FILE_PATH_USERS));

            FileSave(FileLoad(FILE_PATH_CARDS));

        }

        public void StoreCardData(List<string[]> l)
        {
            foreach(string[] array in l)
            {
                switch (array[1])
                {
                    case "Kristallhäst":
                        {
                            Card k = new Kristallhäst(array[0]);
                            cards.Add(k);
                            break;
                        }

                    case "Överpanda":
                        {
                            Card ö = new Överpanda(array[0]);
                            cards.Add(ö);
                            break;
                        }

                    case "Eldtomat":
                        {
                            Card e = new Eldtomat(array[0]);
                            cards.Add(e);
                            break;
                        }
                    default:
                        {
                            Card d = new Dunkerkatt(array[0]);
                            cards.Add(d);
                            break;
                        }
                }
            }
        }  // user data should be handled by database

        private void btnDekonstruering_Click(object sender, EventArgs e)
        {
            if (ValidityChecks.IsCodeInCorrectFormat(messageFromClient))
            {
                string[] commonData = ValidityChecks.Dekonstruering(messageFromClient);
                userInfo = commonData[0];
                cardInfo = commonData[1];

                listBox1.Text = userInfo.ToString(); // DELETE LATER
                listBox1.Text = cardInfo.ToString(); // DELETE LATER
            }
            else { MessageBox.Show("Data input incorrect"); }
            // TODO send message to client
        }
    }
}
