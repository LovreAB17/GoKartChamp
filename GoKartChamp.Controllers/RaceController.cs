using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using GoKartChamp.BaseLib;
using GoKartChamp.BaseLib.Exceptions;
using GoKartChamp.MemBasedDAL;
using GoKartChamp.Model;
using GoKartChamp.Model.Factories;


namespace GoKartChamp.Controllers
{
    public class RaceController
    {

        public void AddRace(IAddRaceView inForm)
        {

            RaceRepository raceRepository = RaceRepository.GetInstance();
            TrackRepository trackRepository = TrackRepository.GetInstance();

            if (inForm.ShowViewModal(trackRepository.GetAllActiveTracks()) == true)
            {
                try
                {
                    string Name = inForm.RaceName;
                    if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Race name is not selected!");

                    DateTime Date = inForm.RaceDate;
                    if(Date < DateTime.Today) throw new ArgumentException("Selected date is in the past!");

                    string RaceTrackName = inForm.RaceTrackName;
                    if (string.IsNullOrEmpty(RaceTrackName)) throw new ArgumentException("Track name is not properly selected!");

                    Track RaceTrack = trackRepository.GetTrackByName(RaceTrackName);

                    int ID = raceRepository.GetNewID();

                    Race newRace = RaceFactory.CreateRace(ID, Name, Date, RaceTrack);

                    raceRepository.AddRace(newRace);

                }
                catch (TrackNotFoundException)
                {
                    MessageBox.Show("Selected track not found! Try again.");

                }
                catch (RaceAlreadyExistsException)
                {
                    MessageBox.Show("Race already exists! Try again.");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message + " Try again.");
                }
            }

        }

        public void EditRace(IEditRaceView inForm, string raceName)
        {

            RaceRepository _raceRepository = RaceRepository.GetInstance();
            TrackRepository _trackRepository = TrackRepository.GetInstance();


            List<Track> tracks = _trackRepository.GetAllActiveTracks();

            try
            {
                Race race = _raceRepository.GetRaceByName(raceName);

                int result = inForm.ShowViewModal(tracks, race);

                if (result == 1)
                {
                    string Name = inForm.RaceName;
                    if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Race name is not selected!");

                    DateTime Date = inForm.RaceDate;
                    if (Date < DateTime.Today) throw new ArgumentException("Selected date is in the past!");

                    string RaceTrackName = inForm.RaceTrackName;
                    if (string.IsNullOrEmpty(RaceTrackName)) throw new ArgumentException("Track name is not properly selected!");

                    Track track = _trackRepository.GetTrackByName(RaceTrackName);

                    _raceRepository.UpdateRace(race.ID, Name, Date, track);

                }
                else if (result == 2)
                {
                    _raceRepository.RemoveRace(race);
                }
            }
            catch (RaceAlreadyExistsException)
            {
                MessageBox.Show("Race name is not available!");
            }
            catch (RaceNotFoundException)
            {
                MessageBox.Show("Race not found!");
            }
            catch (RaceAlreadyFinishedException)
            {
                MessageBox.Show("Race already finished! Can not be deleted!");
            }
            catch (TrackNotFoundException)
            {
                MessageBox.Show("Track not found!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message + " Try again.");
            }
        }


        public void ViewUpcomingRaces(IMainController _mainController, IShowUpcomingRacesView inForm)
        {

            RaceRepository _raceRepository = RaceRepository.GetInstance();

            List<Race> upRaces = _raceRepository.GetAllUnfinishedRaces();

            inForm.ShowModaless(_mainController, upRaces);

        }




        public void ViewFinishedRaces(IMainController _mainController, IShowFinishedRacesView inForm)
        {
            RaceRepository _raceRepository = RaceRepository.GetInstance();

            List<Race> finRaces = _raceRepository.GetAllFinishedRaces();

            inForm.ShowModaless(_mainController, finRaces);

        }

        public void ViewRaceResults(IShowRaceResultsView inForm, string inRaceName)
        {
            RaceRepository _raceRepository = RaceRepository.GetInstance();

            Race _race = _raceRepository.GetRaceByName(inRaceName);

            RaceResults _raceResult = _raceRepository.GetRaceResults(inRaceName);

            List<Driver> positions = _raceResult._positions;

            Driver fastestLap = _raceResult.FastestLap;

            List<int> points = _raceRepository.GetPoints();

            inForm.ShowModaless(_race, positions, fastestLap, points);

        }



        public void EnterRaceResults(IEnterResultsView inForm)
        {
            RaceRepository raceRepository = RaceRepository.GetInstance();
            DriverRepository driverRepository = DriverRepository.GetInstance();


            if (inForm.ShowViewModal(raceRepository.GetAllUnfinishedRaces(), driverRepository.GetAllActiveDrivers()) == true)
            {
                try
                {
                    string RaceName = inForm.RaceName;
                    if (string.IsNullOrEmpty(RaceName)) throw new ArgumentException("Race name is not selected!");

                    Race inRace = raceRepository.GetRaceByName(RaceName);

                    string result = inForm.Result;
                    if (string.IsNullOrEmpty(result)) throw new ArgumentException("Race standings is empty! Fill the textbox!");

                    List<int> driversResultsInt = this.ParseRaceStandings(result, driverRepository);

                    int fastestLap = -1;
                    if (Int32.TryParse(inForm.FastestLap, out fastestLap) == false)     throw new ArgumentException("The fastest lap result is not entered correctly!"); 
                    if (!driversResultsInt.Contains(fastestLap))                        throw new ArgumentException("The fastest lap driver was not in the race!");
                   

                    List<Driver> driversResults = new List<Driver>();
                    List<int> points = raceRepository.GetPoints();

                    for(int i = 0; i < driversResultsInt.Count(); ++i)
                    {

                        int id = driversResultsInt[i];
                        int point = points[i];
                        Driver dr = driverRepository.AddPoints(id,point);
                        driversResults.Add(dr);
                      
                    }

                    Driver inFastestLap = driverRepository.AddPoints(fastestLap, 1);

                    RaceResults results = RaceFactory.CreateResults(driversResults, inFastestLap);

                    raceRepository.EnterResults(inRace.Name, results);


                }
                catch (RaceNotFoundException)
                {
                    MessageBox.Show("Picked race doesn't exist!");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message + " Try again.");
                }
                catch (DriverNotFoundException)
                {
                MessageBox.Show("Driver doesn't exist!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex);
                }
            }

        }

        private List<int> ParseRaceStandings(string result, DriverRepository driverRepository)
        {

            string raceStandings = string.Concat(result.Where(c => !char.IsWhiteSpace(c)));
            if (string.IsNullOrEmpty(raceStandings)) throw new ArgumentException("Race standings is empty! Fill the textbox!");

            List<string> raceStandingsString = result.Split('-').OfType<string>().ToList();
            if(raceStandingsString.Count() > 20) throw new ArgumentException("Too many drivers in race standings!");

            List<int> _driversInt = new List<int>();

            for (int i = 0; i < raceStandingsString.Count(); ++i)
            {
                int gokart = -1;

                if (Int32.TryParse(raceStandingsString[i], out gokart) == false) throw new ArgumentException("The results were not entered correctly!");

                Driver driver = driverRepository.GetDriverByGoKart(gokart);

                if (driver.Active == false) throw new ArgumentException("Driver with gokart number " + driver.GoKart.ToString() + " is not active!");

                _driversInt.Add(gokart);

            }

            if (_driversInt.Count() != _driversInt.Distinct().Count()) throw new ArgumentException("Same driver is on two positions!");

            return _driversInt;
        } 




    }
}
