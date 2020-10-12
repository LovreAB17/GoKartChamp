using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoKartChamp.BaseLib;
using GoKartChamp.BaseLib.Exceptions;
using GoKartChamp.Model.Repositories;
using GoKartChamp.Model;

namespace GoKartChamp.MemBasedDAL
{
    public class RaceRepository : Subject, IRaceRepository
    {

        private List<int> _points = new List<int>() { 25, 18, 15, 12, 10, 8, 6, 4, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private static int _nextID = 1;
        private List<Race> _races = new List<Race>();

        private static  RaceRepository _instance;

        public static RaceRepository GetInstance()
        {
            return _instance ?? (_instance = new RaceRepository());
        }



        public void AddRace(Race race)
        {

            if (_races.Any(rac => rac.ID == race.ID) || _races.Any(rac => rac.Name == race.Name))
            {
                throw new RaceAlreadyExistsException();
            }

            _races.Add(race);

            NotifyObservers();

        }

        public void RemoveRace(Race race)
        {

            if(race.Finished == true)
            {
                throw new RaceAlreadyFinishedException();
            }

            var raceToRemove = _races.Single(r => r.ID == race.ID);
            _races.Remove(raceToRemove);

            NotifyObservers();

        }

        public List<Race> GetAllUnfinishedRaces()
        {

            return _races.Where(a => !a.Finished).ToList();

        }

        public List<Race> GetAllFinishedRaces()
        {

            return _races.Where(a => a.Finished).ToList();

        }

        public Race GetRaceByName(string inName)
        {
            var rac = _races.Find(r => (r.Name == inName));

            if (rac != null)
            {
                return rac;
            }

            throw new RaceNotFoundException();

        }

        public Race GetRaceByID(int inID)
        {
            var rac = _races.Find(r => (r.ID == inID));

            if (rac != null)
            {
                return rac;
            }

            throw new RaceNotFoundException();
        }

        public int GetNewID()
        {
            int ID = _nextID;
            _nextID++;
            return ID;
        }

        public void EnterResults(string inName ,RaceResults inResult)
        {
            var rac = _races.Find(r => (r.Name == inName));

            if (rac != null)
            {
                rac.Finished = true;
                rac.Results = inResult;

                NotifyObservers();
                return;
            }

            throw new RaceNotFoundException();

        }


        public List<int> GetPoints()
        {
            return _points;
        }

        public RaceResults GetRaceResults(string inRaceName)
        {
            var rac = _races.Find(r => (r.Name == inRaceName));

            if (rac != null)
            {
                return rac.Results;
            }

            throw new RaceNotFoundException();
        }

        public bool RaceNameTaken(string raceName)
        {
            var rac = _races.Find(r => (r.Name == raceName));

            if (rac == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }




        public void UpdateRace(int inID, string newName, DateTime newDate, Track newTrack)
        {

            if (_races.Any(rac => (rac.Name == newName && rac.ID != inID)))
            {
                throw new RaceAlreadyExistsException();
            }

            var race = _races.Find(r => (r.ID == inID));

            race.Name = newName;               
            race.Date = newDate;
            race.Track = newTrack;

            NotifyObservers();
            
        }
    }
}
