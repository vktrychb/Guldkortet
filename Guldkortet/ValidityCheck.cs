using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Guldkortet
{
    public static class ValidityCheck
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
            return Regex.IsMatch(code, @"^A[0-9]{7}-K[0-9]{9}\z");
        }

    }
}
