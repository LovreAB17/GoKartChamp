using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib.Exceptions
{
    public class TrackAlreadyExistsException : Exception
    {

        public TrackAlreadyExistsException()
        {

        }

        public TrackAlreadyExistsException(string message) : base(message)
        {

        }


    }
}
