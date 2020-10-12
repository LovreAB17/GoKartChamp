using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GoKartChamp.BaseLib;
using GoKartChamp.Model;
using GoKartChamp.MemBasedDAL;


namespace GoKartChamp.PresentationLayer
{
    public partial class formViewTracks : Form, IShowTracksView, IObserver
    {

        private List<Track> _tracks = null;
        private IMainController _mainController = null;
        private TrackRepository _trackRepository = null;

        public formViewTracks()
        {
            InitializeComponent();
            _trackRepository = TrackRepository.GetInstance();

        }

        public void ShowModaless(IMainController inMainController, List<Track> inTracks)
        {

            _mainController = inMainController;
            _tracks = inTracks;

            UpdateList();

            this.Show();

        }

        private void UpdateList()
        {

            listView1.Items.Clear();

            for (int i = 0; i < _tracks.Count(); ++i)
            {
                Track track = _tracks[i];

                string Name = track.Name;
                string Location = track.Location;
                string Length = track.Length.ToString();

                ListViewItem lvt = new ListViewItem(Name);
                lvt.SubItems.Add(Location);
                lvt.SubItems.Add(Length);

                listView1.Items.Add(lvt);

            }
        }

        private void buttonAddTrack_Click(object sender, EventArgs e)
        {
            _mainController.AddTrack();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void editTrack_DoubleClick(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 1)
            {
                string trackName = listView1.SelectedItems[0].Text;
                _mainController.EditTrack(trackName);

            }
            else
            {
                MessageBox.Show("Select only one item!");
            }

        }

        public void UpdateView()
        {
            _tracks = _trackRepository.GetAllActiveTracks();

            UpdateList();

        }


        private void formViewTracks_FormClosing(object sender, FormClosingEventArgs e)
        {
            _trackRepository.DeleteObserver(this);
        }
    }
}
