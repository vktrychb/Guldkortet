using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guldkortet
{
    internal class Card
    {
        protected string Number;
        protected string Type;

        public Card() { }

        public Card(string cardNumber)
        {
            Number = cardNumber;
        }

        public bool CardInfoMatch(List<Card> cards, string cardInfo)
        {
            if (cards.Count != 0)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].Number == cardInfo)
                    {
                        return true;
                    }
                }
                return false;
            }
            else { return false; }
        }
        

    }

    class Kristallhäst : Card
    {
        public Kristallhäst(string cardNumber) : base (cardNumber)
        {
            Type = "Kristallhäst";
        }
    }

    class Dunkerkatt : Card
    {
        public Dunkerkatt(string cardNumber) : base (cardNumber)
        {
            Type = "Dunkerkatt";
        }
    }

    class Eldtomat : Card
    {
        public Eldtomat(string cardNumber) : base(cardNumber)
        {
            Type = "Eldtomat";
        }
    }

    class Överpanda : Card
    {
        public Överpanda(string cardNumber) : base(cardNumber)
        {
            Type = "Överpanda";
        }
    }
}
