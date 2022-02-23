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

        public void Class(string cardNumber)
        {
            Number = cardNumber;
        }
    }

    class Kristallhäst : Card
    {
        public Kristallhäst()
        {
            Type = "Kristallhäst";
        }
    }

    class Dunkerkatt : Card
    {
        public Dunkerkatt()
        {
            Type = "Dunkerkatt";
        }
    }

    class Eldtomat : Card
    {
        public Eldtomat()
        {
            Type = "Eldtomat";
        }
    }

    class Överpanda : Card
    {
        public Överpanda()
        {
            Type = "Överpanda";
        }
    }
}
