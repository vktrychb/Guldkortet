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
        string[] filePath = new string[2];

        List<string[]> cards = new List<string[]>();
        List<string[]> users = new List<string[]>();

        public Form1()
        {
            InitializeComponent();
        }
        #region Server
        private void avslutaKopplingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listener.Stop();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void startaServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, PORT);
                listener.Start();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            StartReception();
        }

        public async void StartReception()
        {
            try
            {
                client = await listener.AcceptTcpClientAsync();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, Text); }

            checkBox1.BackColor = Color.Turquoise;

            StartReading(client);
        }

        public async void StartReading(TcpClient client)
        {
            byte[] buffer = new byte[1024];

            int start = 0;
            try
            {
                start = await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, Text); return; }

            messageFromClient = Encoding.Unicode.GetString(buffer, 0, start);
            txbTextKontroll.Text = messageFromClient;
        }

        private void btnStartaKlient_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Viktoriya\source\repos\Guldkortet\material\Material\Guldkortet\NOS_Export.exe");
        }  // DELETE LATER

        #endregion

        #region File load & save
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
        #endregion

        #region Browse file

        bool fileTypeIsTxt;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    fileTypeIsTxt = true;
                    dlgOpenFile.Filter = "Text files|*.txt";
                    break;

                case 1:
                    fileTypeIsTxt = false;
                    dlgOpenFile.Filter = "Database|*.mdf";
                    break;
            }
        }
        private void btnBrowsa_Click(object sender, EventArgs e)
        {
            DialogResult fileExplorer = dlgOpenFile.ShowDialog();
            if (fileExplorer == DialogResult.OK)
            {
                cards = FileSave(FileLoad(dlgOpenFile.FileName));
            }
        } //choosing file/database of cards
        private void btnVäljKunddata_Click(object sender, EventArgs e)
        {
            DialogResult fileExplorer = dlgOpenFile.ShowDialog();
            if (fileExplorer == DialogResult.OK)
            {
                users = FileSave(FileLoad(dlgOpenFile.FileName));
            }

        } // choosing file/database of users
        #endregion

        public void SendErrorMessageToClient(int typeOfMessage)
        {
            string message;
            switch (typeOfMessage)
            {
                case 1:
                    message = $"Kund- eller kortnummer är inte korrekt. Du har {3 /*- user.FailedAttempts*/} försök kvar";
                    break;

                case 2:
                    message = "Maximala antal försök var nådda. Ditt konto blockeras. Kontakta administration för vidare information";
                    break;

                default:
                    message = "Ditt konto är blockerad. Kontakta administration för vidare information";
                    break;
            }

            SendMessageToClient(message, client);
        }
        public async void SendMessageToClient(string message, TcpClient client)
        {
            byte[] utData = Encoding.Unicode.GetBytes(message);

            try
            {
                await client.GetStream().WriteAsync(utData, 0, utData.Length);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, Text); return; }
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            AllSearchAndChecksOfRecivedCode();
        } // starting checks and sending data back

        List<GuldkortWinner> peopleWithPriseList = new List<GuldkortWinner>();
        public void AllSearchAndChecksOfRecivedCode()
        {
            if (ValidityChecks.IsCodeInCorrectFormat(messageFromClient))
            {
                string[] commonData = ValidityChecks.Dekonstruering(messageFromClient);

                userInfo = commonData[0];
                cardInfo = commonData[1];

                listBox1.Items.Add(userInfo);//DELETE LATER
                listBox1.Items.Add(cardInfo);//DELETE LATER

                GuldkortWinner winner;

                string[] nameAndKommun = ValidityChecks.UserInfoMatch(users, userInfo);
                if (nameAndKommun != null)
                {
                    winner = new GuldkortWinner(userInfo, nameAndKommun[0], nameAndKommun[1]);

                    if (fileTypeIsTxt) // card/user info check w/ text file
                    {
                        string cardType = ValidityChecks.CardInfoMatch(cards, cardInfo);
                        if (cardType != null)
                        {
                            CardAndUserInfoUniquenessCheck(nameAndKommun, cardType);
                        }
                        else
                        {
                            //send message that no match was found/wrong input
                        }
                    }
                    else
                    {
                        // card/user info check w/ database
                    }
                }
                else { SendErrorMessageToClient(1); /*user.FailedAttempts++*/; }
            }
            else { SendErrorMessageToClient(1); /*user.FailedAttempts++;*/ }

            //if (user.FailedAttempts == 3)
            //{
            //    SendErrorMessageToClient(2);
            //    //ValidityChecks.BlockUser(blockedUsers, userInfo); // TODO save blocked users in text file
            //    return;
            //}
            //else if (blockedUsers.Contains(userInfo))
            //{
            //    SendErrorMessageToClient(3);
            //    btnGetResult.BackColor = Color.Red;
            //    return;
            //}
        }
        public void CardAndUserInfoUniquenessCheck(string[] nameAndKommun, string type)
        {
            for (int i = 0; i < peopleWithPriseList.Count; i++)
            {
                GuldkortWinner item = peopleWithPriseList[i];
                if (item.UserNumber == userInfo)
                {
                    for (int j = 0; j < item.CardList.Count; j++)
                    {
                        Card card = item.CardList[j];
                        if (card.Number == cardInfo)
                        {
                            return;
                        }
                    }
                    item.CardList.Add(new Card(userInfo, cardInfo, type));
                    return;
                }
            }
            
        }

        public void ButtonOnOff(bool kortData, bool kundData, bool dekonstruera)
        {
            btnVäljKortdata.Enabled = kortData;
            btnVäljKunddata.Enabled = kundData;
            btnGetResult.Enabled = dekonstruera;
        }

    }
}
