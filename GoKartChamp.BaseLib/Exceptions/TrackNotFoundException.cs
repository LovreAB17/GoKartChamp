using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib.Exceptions
{
    public class TrackNotFoundException : Exception
    {

         public TrackNotFoundException()
        {

        }

        public TrackNotFoundException(string message) : base(message)
        {

        }

    }
}
