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

namespace GoKartChamp.PresentationLayer
{
    public partial class formShowRaceResults : Form, IShowRaceResultsView
    {
        private Race _race = null;
        private List<Driver> _drivers = null;
        private List<int> _points = null;
        private Driver _fastestLap = null;

        public formShowRaceResults()
        {
            InitializeComponent();
        }

        public void ShowModaless(Race race, List<Driver> drivers, Driver fastestLap, List<int> points)
        {
            _race = race;
            _drivers = drivers;
            _fastestLap = fastestLap;
            _points = points;
         
            ListResults();

            this.Show();

        }

        private void ListResults()
        {

            ListViewItem lvtRace = new ListViewItem(_race.Name);
            lvtRace.SubItems.Add(_race.Date.ToShortDateString());
            lvtRace.SubItems.Add(_race.Track.Name);
            lvtRace.SubItems.Add(_race.Track.Location);

            listView3.Items.Add(lvtRace);

            ListViewItem lvtFast = new ListViewItem(_fastestLap.FirstName);
            lvtFast.SubItems.Add(_fastestLap.LastName);
            lvtFast.SubItems.Add(_fastestLap.GoKart.ToString());


            listView2.Items.Add(lvtFast);


            for (int i = 0; i < _drivers.Count(); ++i)
            {
                Driver driver = _drivers[i];

                string FirstName = driver.FirstName;
                string LastName = driver.LastName;
                string GoKart = driver.GoKart.ToString();
                string Position = (i + 1).ToString() + ".";
                string Points = _points[i].ToString();

                ListViewItem lvt = new ListViewItem(Position);
                lvt.SubItems.Add(FirstName);
                lvt.SubItems.Add(LastName);
                lvt.SubItems.Add(GoKart);
                lvt.SubItems.Add(Points);

                listView1.Items.Add(lvt);

            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
