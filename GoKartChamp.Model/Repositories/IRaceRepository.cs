using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model.Repositories
{
    public interface IRaceRepository
    {
        void AddRace(Race race);

        void RemoveRace(Race race);

        List<Race> GetAllUnfinishedRaces();

        List<Race> GetAllFinishedRaces();

        Race GetRaceByName(string inName);

        Race GetRaceByID(int inID);

        void UpdateRace(int inID, string newName, DateTime newDate, Track newTrack);

        int GetNewID();

        List<int> GetPoints();

        void EnterResults(string inRaceName, RaceResults results);

        RaceResults GetRaceResults(string inRaceName);

    }
}
