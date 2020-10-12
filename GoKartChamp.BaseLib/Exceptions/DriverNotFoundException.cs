using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib.Exceptions
{
    public class DriverNotFoundException : Exception
    {

         public DriverNotFoundException()
        {

        }

        public DriverNotFoundException(string message) : base(message)
        {

        }

    }
}
