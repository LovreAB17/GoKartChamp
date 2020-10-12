using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model
{
    public class Race
    {

        public int ID  { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Track Track { get; set; } 
        public bool Finished { get; set; }
        public RaceResults Results { get; set; }

        public Race(int inID, string inName, DateTime inDate, Track inTrack)
        {
            ID = inID;
            Name = inName;
            Date = inDate;
            Track = inTrack;
            Finished = false;
        }

    }
}
