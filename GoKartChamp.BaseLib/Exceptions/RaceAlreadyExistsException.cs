using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib.Exceptions
{
    public class RaceAlreadyExistsException : Exception
    {

        public RaceAlreadyExistsException()
        {

        }

        public RaceAlreadyExistsException(string message) : base(message)
        {

        }


    }
}
