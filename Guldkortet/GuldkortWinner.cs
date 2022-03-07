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
        public string UserNumber { get; set; }
        public List<Card> CardList = new List<Card>();

        protected string name;
        protected string kommun;
        public int FailedAttempts { get; set; }
        protected string Type;


        public GuldkortWinner() { }

        public GuldkortWinner(string userNumber, string userName, string userKommun)
        {
            UserNumber = userNumber;
            name = userName;
            kommun = userKommun;
        }

        public void AddCardDataToUser(string cardType, string cardNumber, TcpClient client)
        {
            FailedAttempts = 0;
            Card instanceOfCard;
            switch (cardType)
            {
                case "Kristallhäst":
                    {
                        CardList.Add(instanceOfCard = new Kristallhäst(cardNumber));
                        break;
                    }

                case "Överpanda":
                    {
                        CardList.Add(instanceOfCard = new Överpanda(cardNumber));
                        break;
                    }

                case "Eldtomat":
                    {
                        CardList.Add(instanceOfCard = new Eldtomat(cardNumber));
                        break;
                    }
                default:
                    {
                        CardList.Add(instanceOfCard = new Dunderkatt(cardNumber));
                        break;
                    }
            }

            Form1 form = new Form1();
            form.SendMessageToClient(instanceOfCard.ToString(), client);
        }

    }
    class Kristallhäst : Card
    {
        public Kristallhäst(string cardNumber) : base(cardNumber)
        {
            Type = "Kristallhäst";
        }
        public override string ToString()
        {
            return $"Grattis {name}! Du har vunnit ett {Type}-kort som du kan hämta på vårt närmsta spelbutik i {kommun}";
        }
    }

    class Dunderkatt : Card
    {
        public Dunderkatt(string cardNumber) : base(cardNumber)
        {
            Type = "Dunkerkatt";
        }
        public override string ToString()
        {
            return $"Vi gratulerar dig {name} på vinst av {Type}-typ Guldkort! Du kan hämta det på vårt närmsta spelbutik i {kommun}";
        }
    }

    class Eldtomat : Card
    {
        public Eldtomat(string cardNumber) : base(cardNumber)
        {
            Type = "Eldtomat";
        }
        public override string ToString()
        {
            return $"{name}, grattis! Du har vunnit ett {Type}-kort! Det väntar på dig i vårt lokala spelbutik i {kommun}";
        }
    }

    class Överpanda : Card
    {
        public Överpanda(string cardNumber) : base(cardNumber)
        {
            Type = "Överpanda";
        }
        public override string ToString()
        {
            return $"Våra gratulationer till dig, {name}! Du har vunnit ett Guldkort av {Type}-typ. " +
                $"Hämta det i vårt lokala spelbutik i {kommun}";
        }
    }
}


