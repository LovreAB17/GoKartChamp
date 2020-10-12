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
    public partial class formViewFinishedRaces : Form, IShowFinishedRacesView, IObserver
    {
        private List<Race> _finRaces = null;
        private IMainController _mainController = null;
        private RaceRepository _raceRepository = null;

        public formViewFinishedRaces()
        {
            InitializeComponent();
            _raceRepository = RaceRepository.GetInstance();

        }

        public void ShowModaless(IMainController inMainController, List<Race> inFinRaces)
        {

            _mainController = inMainController;
            _finRaces = inFinRaces.OrderBy(x => x.Date).ToList();

            UpdateList();

            this.Show();

        }

        private void UpdateList()
        {

            listView1.Items.Clear();

            for (int i = 0; i < _finRaces.Count(); ++i)
            {
                Race race = _finRaces[i];

                string Name = race.Name;
                string Date = race.Date.ToShortDateString();
                string Track = race.Track.Name;
                string Location = race.Track.Location;
                string Winner = race.Results._positions[0].FirstName + " " + race.Results._positions[0].LastName;

                ListViewItem lvt = new ListViewItem(Name);
                lvt.SubItems.Add(Date);
                lvt.SubItems.Add(Track);
                lvt.SubItems.Add(Location);
                lvt.SubItems.Add(Winner);

                listView1.Items.Add(lvt);

            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewResults_DoubleClick(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 1)
            {
                string selectedRace = listView1.SelectedItems[0].Text;
                _mainController.ViewRaceResults(selectedRace);

            } else
            {
                MessageBox.Show("Select only one item!");
            }

                

        }

        public void UpdateView()
        {
            _finRaces = _raceRepository.GetAllFinishedRaces().OrderBy(x => x.Date).ToList();

            UpdateList();

        }

        private void formViewFinishedRaces_FormClosing(object sender, FormClosingEventArgs e)
        {
            _raceRepository.DeleteObserver(this);
        }
    }
}
