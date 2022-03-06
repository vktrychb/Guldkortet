using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guldkort_Generics
{
    internal class Program
    {
        public static void CardAndUserInfoUniquenessCheck()
        {
            List<Winner> winners = new List<Winner>();
            winners.Add(new Winner("12345", "6789"));
            winners.Add(new Winner("56789", "1234"));
            winners.Add(new Winner("45627", "1235"));


            string userInfo = "12345";
            string cardInfo = "123";

            for (int i = 0; i < winners.Count; i++)
            {
                Winner item = winners[i];
                if (item.UserNumber == userInfo)
                {
                    if (!item.CardNumber.Contains(cardInfo))
                    {
                        item.CardNumber.Add(cardInfo);
                    }
                    return;
                }
            }
            winners.Add(new Winner(userInfo, cardInfo));
        }
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            List<Card> cards = new List<Card>();
            List<Winner> winner = new List<Winner>();

            CardAndUserInfoUniquenessCheck();
            Console.ReadKey();
        }

        
    }
}
