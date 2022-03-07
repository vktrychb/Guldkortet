using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Guldkort_Generics
{
    internal class Program
    {
        public static void CardAndUserInfoUniquenessCheck()
        {
            //List<Winner> winners = new List<Winner>();
            //winners.Add(new Winner("12345", "6789"));
            //winners.Add(new Winner("56789", "1234"));
            //winners.Add(new Winner("45627", "1235"));


            //string userInfo = "12345";
            //string cardInfo = "123";

            //for (int i = 0; i < winners.Count; i++)
            //{
            //    Winner item = winners[i];
            //    if (item.UserNumber == userInfo)
            //    {
            //        if (!item.CardNumber.Contains(cardInfo))
            //        {
            //            item.CardNumber.Add(cardInfo);
            //        }
            //        return;
            //    }
            //}
            //winners.Add(new Winner(userInfo, cardInfo));
        }
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            List<Card> cards = new List<Card>();
            //Winner winner = new Winner();

            //CardAndUserInfoUniquenessCheck();
            //Console.WriteLine(winner.Number);
            //Console.WriteLine(++winner.Number);

            Program program = new Program();

            List<string[]> list = FileLoad(@"C:\Users\Viktoriya\source\repos\Guldkortet\material\Material\Guldkortet\kundlista.txt");
            program.MoveListElementsToClass(list);

            Console.ReadKey();
        }

        List<Winner> winners = new List<Winner>();
        public void MoveListElementsToClass(List<string[]> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                string[] user = l[i];
                winners.Add(new Winner(user[0], user[1], user[2]));
            }
        }

        public static List<string[]> FileLoad(string filePath)
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
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
                return null;
            }

            List<string[]> importedList = new List<string[]>();
            for (int i = 0; i < fileLoad.Count; i++)
            {
                string[] array = fileLoad[i].Split(new string[] { "###" }, StringSplitOptions.None);
                importedList.Add(array);
            }

            return importedList;
        }

    }
}
