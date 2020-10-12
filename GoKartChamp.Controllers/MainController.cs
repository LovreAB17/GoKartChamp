using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoKartChamp.BaseLib;
using GoKartChamp.Model;
using GoKartChamp.MemBasedDAL;

namespace GoKartChamp.Controllers
{
    public class MainController : IMainController
    {

        private readonly IWindowFormsFactory _formsFactory = null;
        private readonly DriverRepository _driverRepository = null;
        private readonly TrackRepository _trackRepository = null;
        private readonly RaceRepository _raceRepository = null;

        public MainController(IWindowFormsFactory inFormFactory, DriverRepository inDriverRepository,
                              TrackRepository inTrackRepository, RaceRepository inRaceRepository)
        {
            _formsFactory = inFormFactory;
            _driverRepository = inDriverRepository;
            _raceRepository = inRaceRepository;
            _trackRepository = inTrackRepository;


          
            //////////////////////////////////
            LoadDefaultModel();/////////////
            //////////////////////////////////
        }

        public void AddDriver()
        {
            var driverController = new DriverController();

            var newForm = _formsFactory.CreateAddDriverView();

            driverController.AddDriver(newForm);

        }

        public void EditDriver(int driverGoKart)
        {
            var driverController = new DriverController();
        
            var newForm = _formsFactory.CreateEditDriverView();
        
            driverController.EditDriver(newForm, driverGoKart);
        }

        public void ViewDrivers()
        {
            var driverController = new DriverController();

            var newForm = _formsFactory.CreateShowDriversView(_driverRepository);

            driverController.ViewDrivers(this, newForm);
            
        }

        public void AddTrack()
        {
            var trackController = new TrackController();

            var newForm = _formsFactory.CreateAddTrackView();

            trackController.AddTrack(newForm);

        }

        public void EditTrack(string trackName)
        {
            var trackController = new TrackController();

            var newForm = _formsFactory.CreateEditTrackView();

            trackController.EditTrack(newForm, trackName);
        }

        public void ViewTracks()
        {
            var trackController = new TrackController();

            var newForm = _formsFactory.CreateShowTracksView(_trackRepository);

            trackController.ViewTracks(this, newForm);
        }


        public void AddRace()
        {
            var raceController = new RaceController();

            var newForm = _formsFactory.CreateAddRaceView();

            raceController.AddRace(newForm);
        }

        public void EditRace(string raceName)
        {
            var raceController = new RaceController();

            var newForm = _formsFactory.CreateEditRaceView();

            raceController.EditRace(newForm, raceName);
        }


        public void ViewUpcomingRaces()
        {
            var raceController = new RaceController();

            var newForm = _formsFactory.CreateShowUpcomingRacesView(_raceRepository);

            raceController.ViewUpcomingRaces(this, newForm);

        }

        public void ViewFinishedRaces()
        {
            var raceController = new RaceController();

            var newForm = _formsFactory.CreateShowFinishedRacesView(_raceRepository);

            raceController.ViewFinishedRaces(this, newForm);

        }

        public void EnterRaceResults()
        {
            var raceController = new RaceController();

            var newForm = _formsFactory.CreateEnterRaceResultsView();

            raceController.EnterRaceResults(newForm);

        }


        public void ViewRaceResults(string raceName)
        {
            var raceController = new RaceController();

            var newForm = _formsFactory.CreateShowRaceResultsView();

            raceController.ViewRaceResults(newForm, raceName);
        }

        public void ViewStandings()
        {
            var driverController = new DriverController();

            var newForm = _formsFactory.CreateShowStandingsView(_raceRepository, _driverRepository);

            driverController.ViewStandings(newForm);
        }

        public void LoadDefaultModel()
        {
            _driverRepository.AddDriver(new Driver(16, "Charles", "Leclerc"));
            _driverRepository.AddDriver(new Driver(5, "Sebastian", "Vettel"));
            _driverRepository.AddDriver(new Driver(44, "Lewis", "Hamilton"));
            _driverRepository.AddDriver(new Driver(77, "Valteri", "Bottas"));
            _driverRepository.AddDriver(new Driver(3, "Max", "Verstapen"));
            _driverRepository.AddDriver(new Driver(55, "Carlos", "Seinz"));

            _trackRepository.AddTrack(new Track(_trackRepository.GetNewID(), "Melbourne Grand Prix Circuit", "Australia", 5303000));
            _trackRepository.AddTrack(new Track(_trackRepository.GetNewID(), "Bahrein International Circuit", "Bahrein", 5412000));
            _trackRepository.AddTrack(new Track(_trackRepository.GetNewID(), "Spa-Francorchhamps", "Belgium", 7004000));
            _trackRepository.AddTrack(new Track(_trackRepository.GetNewID(), "Shangai International Circuit", "China", 5451000));
            _trackRepository.AddTrack(new Track(_trackRepository.GetNewID(), "Hanoi Circuit", "Vietnam", 5607000));


            _raceRepository.AddRace(new Race(_raceRepository.GetNewID(), "Australia GP", new DateTime(2020, 3, 15), _trackRepository.GetTrackByName("Melbourne Grand Prix Circuit")));
            _raceRepository.AddRace(new Race(_raceRepository.GetNewID(), "Bahrein GP", new DateTime(2020, 3, 22), _trackRepository.GetTrackByName("Bahrein International Circuit")));
            _raceRepository.AddRace(new Race(_raceRepository.GetNewID(), "Vietnam GP", new DateTime(2020, 4, 5), _trackRepository.GetTrackByName("Hanoi Circuit")));
            _raceRepository.AddRace(new Race(_raceRepository.GetNewID(), "China GP", new DateTime(2020, 4, 19), _trackRepository.GetTrackByName("Shangai International Circuit")));

            RaceResults raceResults = new RaceResults(_driverRepository.GetAllActiveDrivers(), _driverRepository.GetDriverByGoKart(16));
            _raceRepository.EnterResults("Australia GP", raceResults);
            _driverRepository.AddPoints(16, 26);
            _driverRepository.AddPoints(5, 18);
            _driverRepository.AddPoints(44, 15);
            _driverRepository.AddPoints(77, 12);
            _driverRepository.AddPoints(3, 10);
            _driverRepository.AddPoints(55, 8);

        }

    }
}
