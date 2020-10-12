using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoKartChamp.Model;

namespace GoKartChamp.BaseLib
{
    public interface IEditRaceView
    {

        int ShowViewModal(List<Track> tracks, Race race);

        string RaceName { get; }
        DateTime RaceDate { get; }
        string RaceTrackName { get; }
    }
}
