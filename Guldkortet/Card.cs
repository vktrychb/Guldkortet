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
        public bool UserInfoMatch(List<string[]> users, string userInfo)
        {
            if (users.Count != 0)
            {
                foreach (var user in users)
                {
                    if (user[0] == userInfo) // kundnummer ligger under index 0
                    {
                        return true;
                    }
                }
                return false;
            }
            else { return false; }
        }

        public void BlockUser(List<string[]> users, List<string> blockedUsers, string user)
        {
            if (users.Count > 0)
            {
                blockedUsers.Add(user);
            }
        }
        public bool IsUserBlocked(List<string[]> users, List<string> blockedUsers, string user)
        {
            if (users.Count > 0)
            {
                for (int i = 0; i < blockedUsers.Count; i++)
                {
                    if (blockedUsers[i] == user) { return true; }
                }
            }
            return false;
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
