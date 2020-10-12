using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib.Exceptions
{
    public class RaceAlreadyFinishedException : Exception
    {

        public RaceAlreadyFinishedException()
        {

        }

        public RaceAlreadyFinishedException(string message) : base(message)
        {

        }


    }
}
