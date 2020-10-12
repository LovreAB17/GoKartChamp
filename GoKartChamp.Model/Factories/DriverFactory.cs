using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model.Factories
{
    public class DriverFactory
    {

        public static Driver CreateDriver(int inGoKart, string inFirstName, string inLastName)
        {
            return new Driver(inGoKart, inFirstName, inLastName);
        }

    }
}
