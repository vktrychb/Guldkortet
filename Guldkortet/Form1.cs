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
            menuStrip1.Enabled = false;
            ButtonOnOff(false, false);
        }

        #region Server

        // STOP CONNECTION BTN
        private void avslutaKopplingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopConnection();
        }

        //EXITS SERVER
        private void exitServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (client.Connected)
            {
                StopConnection();
            }
            Application.Exit();
        }

        public void StopConnection()
        {
            try
            {
                listener.Stop();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        //START CONNECTION BTN
        private void startaServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartConnection();
        }

        public void StartConnection()
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

            chbConnection.Checked = true;

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

            ProcessingOfRecievedData();
            StartReading(client);
        }

        //DELETE LATER
        private void startaKlientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\Viktoriya\source\repos\Guldkortet\material\Material\Guldkortet\NOS_Export.exe");

        }
        #endregion

        #region TXT file load & save to lists
        // sister methods, two parts of one proccess 
        // of uploading data into server's lists
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

        #region DATABASE load + save to lists 
        //equialent to TXT data uploading but for MDFs
        //and including connection to SQL
        public void StartSQLConnection(string filePath, bool isItCardDatabase)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=" + filePath + ";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
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

        #region saving changes to TXT file
        // saves previously recieved user's cards
        public void SaveChanges()
        {
            using (StreamWriter writer = new StreamWriter("Updated Winner List.txt"))
            {
                writer.WriteLine(messageFromClient);
            }
        }

        //two parts of same process of updating
        //to iclude previously recieved cards
        public void CheckForUpdates()
        {
            try
            {
                List<string> l = new List<string>();
                using (StreamReader reader = new StreamReader("Updated Winner List.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        l.Add(line);
                    }
                }
                UpdateWinnerList(l);
            }
            catch (Exception ex) { }
        }
        public void UpdateWinnerList(List<string> l)
        {
            foreach (string line in l)
            {
                string[] tempArray = ValidityChecks.Dekonstruering(line);
                string userNr = tempArray[0];
                string cardNr = tempArray[1];

                GuldkortWinner w = ValidityChecks.UserInfoMatch(winnerList, userNr);
                string cardType = ValidityChecks.CardInfoMatch(cards, cardNr);
                AddNewCard(cardType, cardInfo, w);
            }
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
            ButtonOnOff(true, true);
        }

        //choosing file/database of cards
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
                chbCardData.Checked = true;
            }
            if (chbCardData.Checked & chbUserData.Checked)
            {
                menuStrip1.Enabled = true;
            }
        }

        // choosing file/database of users
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
                chbUserData.Checked = true;
            }

            if(chbCardData.Checked & chbUserData.Checked)
            {
                menuStrip1.Enabled = true;
            }
        } 

        List<GuldkortWinner> winnerList = new List<GuldkortWinner>();
        public void MoveUserListToClass(List<string[]> userList)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                string[] user = userList[i];
                winnerList.Add(new GuldkortWinner(user[0], user[1], user[2]));
            }
        }

        //swithces choose file btns on/off
        public void ButtonOnOff(bool kortData, bool kundData)
        {
            btnVäljKortdata.Enabled = kortData;
            btnVäljKunddata.Enabled = kundData;
        }
        #endregion

        #region Send back message
        public void SendErrorMessage(int typeOfMessage)
        {
            string message;
            switch (typeOfMessage)
            {
                case 1:
                    message = $"Kortnummer är inte korrekt. Du har {3 - clientsFailedAttempts} försök kvar";
                    break;

                case 2:
                    message = "Maximala antal försök var nådda. Ditt konto är blockerad. Kontakta administration för vidare information";
                    break;

                default:
                    message = "Kund- eller kortnummer är inte korrekt";
                    break;
            }

            SendMessageToClient(message);
        }
        public async void SendMessageToClient(string message)
        {
            byte[] utData = Encoding.Unicode.GetBytes(message);

            try
            {
                await client.GetStream().WriteAsync(utData, 0, utData.Length);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, Text); return; }
        }

        GuldkortWinner winner;
        int clientsFailedAttempts;
        public void ProcessingOfRecievedData()
        {
            CheckForUpdates();

            if (ValidityChecks.IsCodeInCorrectFormat(messageFromClient))
            {
                string[] commonData = ValidityChecks.Dekonstruering(messageFromClient);

                userInfo = commonData[0];
                cardInfo = commonData[1];

                winner = ValidityChecks.UserInfoMatch(winnerList, userInfo);
                if (clientsFailedAttempts < 3) 
                {
                    if (winner != null)
                    {
                        string cardType = ValidityChecks.CardInfoMatch(cards, cardInfo);

                        if (cardType != null)
                        {
                            int instanceOfCard = AddNewCard(cardType, cardInfo, winner);
                            if (instanceOfCard >= 0)
                            {
                                SendCongratulations(winner, instanceOfCard);
                            }
                            clientsFailedAttempts = 0;
                            SaveChanges();
                            StopConnection();
                            StartConnection();
                        }
                        else
                        {
                            clientsFailedAttempts++;
                            SendErrorMessage(1);
                            //StartReception();
                        }
                    }
                    else { SendErrorMessage(1); clientsFailedAttempts++; }
                }
                else { SendErrorMessage(2); client.Close(); }
                //method for proper blocking can be made, then client is
                //saved to a file/database and won't get access to server
                //OR make user wait some time (eg 30 min)
            }
            else { SendErrorMessage(1); clientsFailedAttempts++; }
        }

        //checks if such card exists and adds new one if not
        public int AddNewCard(string cardType, string cardInfo, GuldkortWinner winner)
        {
            for (int j = 0; j < winner.CardList.Count; j++)
            {
                Card card = winner.CardList[j];
                if (card.Number == cardInfo)
                {
                    return winner.CardList.IndexOf(card);
                }
            }
            int instanceOfCard = winner.AddCardDataToUser(cardType, cardInfo, client);

            SendCongratulations(winner, instanceOfCard);

            return -1;
        }

        //formulates end message and sends it back to client-program
        public void SendCongratulations(GuldkortWinner winner, int indexOfCardInstance)
        {
            string kommun = winner.kommun;
            string cardType = winner.CardList[indexOfCardInstance].Type;
            string userName = winner.name;

            string message = $"Vi gratulerar dig {userName} på vinst av {cardType}-typ" +
                $" Guldkort! Du kan hämta det på vårt närmsta spelbutik i {kommun}";

            SendMessageToClient(message);
        }
        #endregion
    }
}
