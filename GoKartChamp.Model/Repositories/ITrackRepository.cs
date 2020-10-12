using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model.Repositories
{
    public interface ITrackRepository
    {

        void AddTrack(Track track);

        void RemoveTrack(Track track);

        void UpdateTrack(int inID, string newName, int newLength);

        List<Track> GetAllActiveTracks();

        Track GetTrackByName(string inName);

        Track GetTrackrByID(int inID);

        int GetNewID();

    }
}
