using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model.Factories
{
    public class RaceFactory
    {

        public static Race CreateRace(int inID, string inName, DateTime inDate, Track inTrack)
        {
            return new Race(inID, inName, inDate, inTrack);
        }

        public static RaceResults CreateResults(List<Driver> inPositions, Driver inFastestLap)
        {
            return new RaceResults(inPositions, inFastestLap);
        }

    }
}
