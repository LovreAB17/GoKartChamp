using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib.Exceptions
{
    public class DriverAlreadyExistsException : Exception
    {

        public DriverAlreadyExistsException()
        {

        }

        public DriverAlreadyExistsException(string message) : base(message)
        {

        }


    }
}
