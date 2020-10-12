using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoKartChamp.Model;


namespace GoKartChamp.BaseLib
{
    public interface IAddRaceView
    {

        bool ShowViewModal(List<Track> tracks);

        string RaceName { get; }
        DateTime RaceDate { get; }
        string RaceTrackName { get; }

    }
}
