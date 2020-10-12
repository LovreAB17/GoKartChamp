using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib.Exceptions
{
    public class RaceNotFoundException : Exception
    {

         public RaceNotFoundException()
        {

        }

        public RaceNotFoundException(string message) : base(message)
        {

        }

    }
}
