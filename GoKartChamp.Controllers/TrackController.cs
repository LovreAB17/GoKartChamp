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
    public class TrackController
    {

        public void AddTrack(IAddTrackView inForm)
        {

            TrackRepository trackRepository = TrackRepository.GetInstance();

            if (inForm.ShowViewModal() == true)
            {
                try
                {
                    string Name = inForm.TrackName;
                    if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Track name is not selected!");

                    string Location = inForm.TrackLocation;
                    if (string.IsNullOrEmpty(Location)) throw new ArgumentException("Location is not selected!");

                    int Length = inForm.TrackLength;

                    if (Length < 0) throw new ArgumentException("Length value not supported!");

                    int ID = trackRepository.GetNewID();

                    Track newTrack = TrackFactory.CreateTrack(ID, Name, Location, Length);

                    trackRepository.AddTrack(newTrack);

                }
                catch (TrackAlreadyExistsException)
                {
                    MessageBox.Show("Track already exists!");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        public void ViewTracks(IMainController _mainController, IShowTracksView inForm)
        {
            TrackRepository _trackRepository = TrackRepository.GetInstance();

            List<Track> tracks = _trackRepository.GetAllActiveTracks();

            inForm.ShowModaless(_mainController, tracks);

        }

        public void EditTrack(IEditTrackView inForm, string trackName)
        {
            TrackRepository _trackRepository = TrackRepository.GetInstance();

            Track track = _trackRepository.GetTrackByName(trackName);

            int result = inForm.ShowViewModal(track);

            try
            {
                if (result == 1)
                {
                    string Name = inForm.TrackName;
                    if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Track name is not selected!");

                    if (inForm.Length < 0) throw new ArgumentException("Length value not supported!");

                    _trackRepository.UpdateTrack(track.ID, Name, inForm.Length);
                }
                else if (result == 2)
                {
                    _trackRepository.RemoveTrack(track);
                }
            }
            catch (TrackNotFoundException)
            {
                MessageBox.Show("Track not found!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
