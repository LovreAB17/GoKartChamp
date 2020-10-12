using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model
{
    public class Track
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Length { get; set; }
        public bool Active { get; set; }

        public Track(int inID, string inName, string inLocation, int inLength)
        {
            Name = inName;
            Location = inLocation;
            Length = inLength;
            Active = true;
            ID = inID;
        }

    }
}
