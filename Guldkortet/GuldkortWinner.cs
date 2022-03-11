using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace Guldkortet
{
    public class GuldkortWinner
    {
        public string UserNumber { get; }
        public List<Card> CardList = new List<Card>();

        public string name { get; }
        public string kommun { get; }


        public GuldkortWinner() { }

        public GuldkortWinner(string userNumber, string userName, string userKommun)
        {
            UserNumber = userNumber;
            name = userName;
            kommun = userKommun;
        }

        //adds card to previously existing user
        public int AddCardDataToUser(string cardType, string cardNumber, TcpClient client)
        {
            Card instanceOfCard;
            CardList.Add(instanceOfCard = new Card(cardNumber, cardType));

            return CardList.IndexOf(instanceOfCard);
        }
    }
}