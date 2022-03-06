﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guldkort_Generics
{
    internal class Winner
    {
        public string UserNumber { get; set; }
        public List<string> CardNumber = new List<string>();

        public Winner() { }

        public Winner (string user, string card)
        {
            UserNumber = user;
            CardNumber.Add(card);
        }
    }
    class Type1 : Winner
    {
        public Type1()
        {
            string CardType = "Type 1";
        }
    }

    class Type2 : Winner
    {
        public Type2()
        {
            string CardType = "Type 2";
        }
    }

    class Type3 : Winner
{
        public Type3()
        {
            string CardType = "Type 3";
        }
    }
}
