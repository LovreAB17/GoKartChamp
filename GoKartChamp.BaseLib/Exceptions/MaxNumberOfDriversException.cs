using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib.Exceptions
{
    public class MaxNumberOfDriversException : Exception
    {

        public MaxNumberOfDriversException()
        {

        }

        public MaxNumberOfDriversException(string message) : base(message)
        {

        }


    }
}
