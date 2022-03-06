using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guldkortet
{
    internal class Card : GuldkortWinner
    {
        public string Number { get; set; }

        public Card() { }

        public Card(string cardNumber)
        {
            this.Number = cardNumber;
        }

        // needed??
        public Card(string userInfo, string cardInfo, string type)
        {
            if (userInfo == UserNumber)
            {
                Number = cardInfo;
                switch (type)
                {
                    case "Kristallhäst":
                        {
                            CardList.Add(new Kristallhäst(cardInfo));
                            break;
                        }

                    case "Överpanda":
                        {
                            CardList.Add(new Överpanda(cardInfo));
                            break;
                        }

                    case "Eldtomat":
                        {
                            CardList.Add(new Eldtomat(cardInfo));
                            break;
                        }
                    default:
                        {
                            CardList.Add(new Dunderkatt(cardInfo));
                            break;
                        }
                }
            }
        }

        public override string ToString()
        {
            return Type;
        }
    }

}