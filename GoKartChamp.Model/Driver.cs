using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model
{
    public class Driver
    {

        public int GoKart { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Points { get; set; }
        public bool Active { get; set; }

        public Driver(int inGoKart, string inFirstName, string inLastName)
        {

            GoKart = inGoKart;
            FirstName = inFirstName;
            LastName = inLastName;
            Points = 0;
            Active = true;

        }

    }
}
