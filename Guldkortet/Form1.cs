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
using System.Data.SqlClient;

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
                if(fileTypeIsTxt)
                {
                    cards = FileSave(FileLoad(dlgOpenFile.FileName));
                }
                else
                {
                    StartSQLConnection(dlgOpenFile.FileName, true);
                }
            }
        } //choosing file/database of cards
        private void btnVäljKunddata_Click(object sender, EventArgs e)
        {
            DialogResult fileExplorer = dlgOpenFile.ShowDialog();
            if (fileExplorer == DialogResult.OK)
            {
                if(fileTypeIsTxt)
                {
                    List<string[]> users = FileSave(FileLoad(dlgOpenFile.FileName));
                    MoveUserListToClass(users);
                }
                else
                {
                    StartSQLConnection(dlgOpenFile.FileName, false);
                }
            }

        } // choosing file/database of users

        List<GuldkortWinner> winnerList = new List<GuldkortWinner>();
        public void MoveUserListToClass(List<string[]> userList)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                string[] user = userList[i];
                winnerList.Add(new GuldkortWinner(user[0], user[1], user[2]));
            }
        }

        public void StartSQLConnection(string filePath, bool isItCardDatabase)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=" + filePath + ";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                if (isItCardDatabase)
                {
                    ReadFromCardDatabase(connection);
                }
                else
                {
                    ReadFromUserDatabase(connection);
                }
            }
        }

        public void ReadFromCardDatabase(SqlConnection connection)
        {
            string query = "SELECT * FROM Kort";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string cardNr = reader.GetString(0);
                    string cardType = reader.GetString(1);

                    cards.Add(new string[] { cardNr, cardType });
                }
            }
        }

        public void ReadFromUserDatabase(SqlConnection connection)
        {
            string query = "SELECT * FROM Kunder";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string userNr = reader.GetString(0);
                    string userName = reader.GetString(1);
                    string userKommun = reader.GetString(2);

                    winnerList.Add(new GuldkortWinner(userNr, userName, userKommun));
                }
            }
        }
        #endregion

        #region Send back message
        public void SendErrorMessageToClient(int typeOfMessage)
        {
            string message;
            switch (typeOfMessage)
            {
                case 1:
                    message = $"Kortnummer är inte korrekt. Du har {3 - winner.FailedAttempts} försök kvar";
                    break;

                case 2:
                    message = "Maximala antal försök var nådda. Ditt konto är blockerad. Kontakta administration för vidare information";
                    break;

                default:
                    message = "Kund- eller kortnummer är inte korrekt";
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

        GuldkortWinner winner;
        public void AllSearchAndChecksOfRecivedCode()
        {
            GuldkortWinner loser = new GuldkortWinner();
            if (ValidityChecks.IsCodeInCorrectFormat(messageFromClient))
            {
                string[] commonData = ValidityChecks.Dekonstruering(messageFromClient);

                userInfo = commonData[0];
                cardInfo = commonData[1];

                listBox1.Items.Add(userInfo);//DELETE LATER
                listBox1.Items.Add(cardInfo);//DELETE LATER

                winner = ValidityChecks.UserInfoMatch(winnerList, userInfo);
                if (winner != null)
                {
                    if (winner.FailedAttempts < 3)
                    {
                        if (fileTypeIsTxt) // card/user info check w/ text file
                        {
                            string cardType = ValidityChecks.CardInfoMatch(cards, cardInfo);

                            if (cardType != null)
                            {
                                Card instanceOfCard = AddNewCard(cardType, cardInfo, winner);
                                if (instanceOfCard != null)
                                {
                                    SendMessageToClient(instanceOfCard.ToString(), client);
                                }
                            }
                            else
                            {
                                winner.FailedAttempts++;
                                SendErrorMessageToClient(1);
                            }
                        }
                        else
                        {
                            // card/user info check w/ database
                        }
                    }
                    else { SendErrorMessageToClient(2); }
                }
                else
                {
                    SendErrorMessageToClient(3);
                }
            }
            else { SendErrorMessageToClient(1); loser.FailedAttempts++; }
        }

        public Card AddNewCard(string cardType, string cardInfo, GuldkortWinner winner)
        {
            for (int j = 0; j < winner.CardList.Count; j++)
            {
                Card card = winner.CardList[j];
                if (card.Number == cardInfo)
                {
                    return card;
                }
            }
            winner.AddCardDataToUser(cardType, cardInfo, client);
            return null;
        }
        #endregion

        public void ButtonOnOff(bool kortData, bool kundData, bool dekonstruera)
        {
            btnVäljKortdata.Enabled = kortData;
            btnVäljKunddata.Enabled = kundData;
            btnGetResult.Enabled = dekonstruera;
        }

    }
}
