using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib
{
    public interface IMainController
    {

        void AddDriver();

        void ViewDrivers();

        void EditDriver(int goKart);

        void AddTrack();

        void EditTrack(string trackName);

        void AddRace();

        void EditRace(string raceName);

        void ViewTracks();

        void ViewUpcomingRaces();

        void ViewFinishedRaces();

        void EnterRaceResults();

        void ViewRaceResults(string raceName);

        void ViewStandings();

    }
}
