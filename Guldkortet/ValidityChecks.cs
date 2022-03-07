using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Guldkortet
{
    public static class ValidityChecks
    {
        public static string[] Dekonstruering(string messageFromClient)
        {
            string[] messageArray = new string[2];
            string pattern = "-";
            messageArray = Regex.Split(messageFromClient, pattern); // messageFromClient.Split(new string[] { "-" }, StringSplitOptions.None);
            return messageArray;
        }

        public static bool IsCodeInCorrectFormat(string code)
        {
            return Regex.IsMatch(code.Trim(), @"^A[0-9]{7}?-K[0-9]{9}?\z");
        }

        public static GuldkortWinner UserInfoMatch(List<GuldkortWinner> users, string userInfo)
        {
            if (users.Count != 0)
            {
                foreach (var user in users)
                {
                    if (user.UserNumber == userInfo) // kundnummer ligger under index 0
                    {
                        return user; 
                    }
                }
            }
            return null;
        }

        public static string CardInfoMatch(List<string[]> cards, string cardInfo)
        {
            if (cards.Count != 0)
            {
                foreach (var card in cards)
                {
                    if (card[0] == cardInfo)
                    {
                        return card[1];
                    }
                }
            }
            return null;
        } //SEARCH METHOD

    }
}
