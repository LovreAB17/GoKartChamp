using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using GoKartChamp.BaseLib;
using GoKartChamp.MemBasedDAL;
using GoKartChamp.Model.Repositories;

namespace GoKartChamp.PresentationLayer
{
    public class WindowFormsFactory : IWindowFormsFactory
    {
        public IAddDriverView CreateAddDriverView()
        {
            var newForm = new formAddDriver();
            return newForm;
        }

        public IShowDriversView CreateShowDriversView(Subject subject)
        {
            var newForm = new formViewDrivers();
            subject.AddObserver(newForm);
    
            return newForm;
        }

        public IEditDriverView CreateEditDriverView()
        {
            var newForm = new formEditDriver();
            return newForm;
        }

        public IAddTrackView CreateAddTrackView()
        {
            var newForm = new formAddTrack();
            return newForm;
        }

        public IShowTracksView CreateShowTracksView(Subject subject)
        {
            var newForm = new formViewTracks();
            subject.AddObserver(newForm);
            return newForm;
        }

        public IEditTrackView CreateEditTrackView()
        {
            var newForm = new formEditTrack();
            return newForm;
        }

        public IAddRaceView CreateAddRaceView()
        {
            var newForm = new formAddRace();
            return newForm;
        }

        public IEditRaceView CreateEditRaceView()
        {
            var newForm = new formEditRace();
            return newForm;
        }

        public IShowUpcomingRacesView CreateShowUpcomingRacesView(Subject subject)
        {
            var newForm = new formViewUpcomingRaces();
            subject.AddObserver(newForm);
            return newForm;
        }

        public IShowFinishedRacesView CreateShowFinishedRacesView(Subject subject)
        {
            var newForm = new formViewFinishedRaces();
            subject.AddObserver(newForm);
            return newForm;
        }

        public IEnterResultsView CreateEnterRaceResultsView()
        {
            var newForm = new formEnterResults();
            return newForm;
        }


        public IShowRaceResultsView CreateShowRaceResultsView()
        {
            var newForm = new formShowRaceResults();
            return newForm;
        }

        public IShowStandingsView CreateShowStandingsView(Subject subject1, Subject subject2)
        {
            var newForm = new formViewStandings();
            subject1.AddObserver(newForm);
            subject2.AddObserver(newForm);
            return newForm;

        }

    }
}
