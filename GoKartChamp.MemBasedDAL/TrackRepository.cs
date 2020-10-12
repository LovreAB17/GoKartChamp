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
    public class TrackRepository : Subject, ITrackRepository
    {
        private int _nextID = 1;

        private List<Track> _tracks = new List<Track>();

        private static  TrackRepository _instance = new TrackRepository();

        public static TrackRepository GetInstance()
        {
            return _instance ?? (_instance = new TrackRepository());
        }


        public void AddTrack(Track track)
        {

            if (!_tracks.Any(trk => trk.ID == track.ID))
            {

                _tracks.Add(track);

                NotifyObservers();

                return;

            }

            throw new TrackAlreadyExistsException();

        }

        public void RemoveTrack(Track track)
        {
            track.Active = false;

            NotifyObservers();
        }

        public void UpdateTrack(int inID, string newName, int newLength)
        {

            var track = _tracks.Find(t => t.ID == inID);

            if (track != null)
            {

                track.Name = newName;
                track.Length = newLength;

                NotifyObservers();

                return;
            }

            throw new TrackNotFoundException();

        }

        public Track GetTrackByName(string inName)
        {
            var trk = _tracks.Find(t => (t.Name == inName));

            if (trk != null)
            {
                return trk;
            }

            throw new TrackNotFoundException();

        }

        public Track GetTrackrByID(int inID)
        {
            var trk = _tracks.Find(t => t.ID == inID);

            if (trk != null)
            {
                return trk;
            }

            throw new TrackNotFoundException();

        }

        public List<Track> GetAllActiveTracks()
        {

            return _tracks.Where(a => a.Active).ToList();

        }

        public int GetNewID()
        {
            int ID = _nextID;
            _nextID++;
            return ID;
        }

    }
}
