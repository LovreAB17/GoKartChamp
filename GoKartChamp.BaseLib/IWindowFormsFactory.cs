using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.BaseLib
{
    public interface IWindowFormsFactory
    {
        IAddDriverView CreateAddDriverView();
        IShowDriversView CreateShowDriversView(Subject subject);
        IEditDriverView CreateEditDriverView();

        IAddTrackView CreateAddTrackView();
        IShowTracksView CreateShowTracksView(Subject subject);
        IEditTrackView CreateEditTrackView();

        IAddRaceView CreateAddRaceView();
        IEditRaceView CreateEditRaceView();

        IShowUpcomingRacesView CreateShowUpcomingRacesView(Subject subject);
        IShowFinishedRacesView CreateShowFinishedRacesView(Subject subject);

        IEnterResultsView CreateEnterRaceResultsView();
        IShowRaceResultsView CreateShowRaceResultsView();
        

        IShowStandingsView CreateShowStandingsView(Subject subject1, Subject subject2);

    }
    
}
