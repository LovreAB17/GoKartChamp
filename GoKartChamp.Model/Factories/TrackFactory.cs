using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model.Factories
{
    public class TrackFactory
    {

        public static Track CreateTrack(int inID, string inName, string inLocation, int inLength)
        {
            return new Track(inID, inName, inLocation, inLength);
        }

    }
}
