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
    public partial class formViewUpcomingRaces : Form, IShowUpcomingRacesView, IObserver
    {
        private List<Race> _upRaces = null;
        private IMainController _mainController = null;
        private RaceRepository _raceRepository = null;

        public formViewUpcomingRaces()
        {
            InitializeComponent();
            _raceRepository = RaceRepository.GetInstance();
        }

        public void ShowModaless(IMainController inMainController, List<Race> inUpRaces)
        {

            if(inUpRaces.Count == 0)
            {
                buttonEnterResults.Enabled = false;
            }

            _mainController = inMainController;
            _upRaces = inUpRaces.OrderBy(x => x.Date).ToList();

            UpdateList();

            this.Show();

        }

        private void UpdateList()
        {
            listView1.Items.Clear();

            for (int i = 0; i < _upRaces.Count(); ++i)
            {
                Race race = _upRaces[i];

                string Name = race.Name;
                string Date = race.Date.ToShortDateString();
                string Track = race.Track.Name;
                string Location = race.Track.Location;

                ListViewItem lvt = new ListViewItem(Name);
                lvt.SubItems.Add(Date);
                lvt.SubItems.Add(Track);
                lvt.SubItems.Add(Location);

                listView1.Items.Add(lvt);

            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEnterResults_Click(object sender, EventArgs e)
        {
            _mainController.EnterRaceResults();
        }

        private void editRace_DoubleClick(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 1)
            {
                string raceName = listView1.SelectedItems[0].Text;
                _mainController.EditRace(raceName);

            }
            else
            {
                MessageBox.Show("Select only one item!");
            }

        }

        public void UpdateView()
        {
            _upRaces = _raceRepository.GetAllUnfinishedRaces().OrderBy(x => x.Date).ToList();

            UpdateList();
        }

        private void formViewUpcomingRaces_FormClosing(object sender, FormClosingEventArgs e)
        {
            _raceRepository.DeleteObserver(this);
        }
    }
}
