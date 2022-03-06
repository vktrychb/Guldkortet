using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guldkort_Generics
{
    internal class User
    {
        string UserNumber;
        string Name;
        string Commune;

        public User(string userMunber, string userName, string userCommune)
        {
            UserNumber = userMunber;
            Name = userName;
            Commune = userCommune;
        }
    }
}
