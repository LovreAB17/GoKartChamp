using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model
{
    public class RaceResults
    {

        public List<Driver> _positions { get; set; }

        public Driver FastestLap { get; set; }

        public RaceResults(List<Driver> inPositions, Driver inFastestLap)
        {

            _positions = inPositions;

            FastestLap = inFastestLap;

        }

    }
}
