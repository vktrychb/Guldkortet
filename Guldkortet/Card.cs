using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guldkortet
{
    public class Card : GuldkortWinner
    {
        public string Number { get; set; }
        public string Type { get; set; }

        public Card() { }

        public Card(string cardNumber, string cardType)
        {
            Number = cardNumber;
            Type = cardType;
        }
    }

}