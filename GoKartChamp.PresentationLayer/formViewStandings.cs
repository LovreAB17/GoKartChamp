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
    public partial class formViewStandings : Form, IShowStandingsView, IObserver
    {

        private List<Driver> _drivers = null;
        private DriverRepository _driverRepository = null;
        private RaceRepository _raceRepository = null;

        public formViewStandings()
        {
            InitializeComponent();
            _driverRepository = DriverRepository.GetInstance();
            _raceRepository = RaceRepository.GetInstance();
        }

        public void ShowModaless(List<Driver> inDrivers)
        {
            _drivers = inDrivers;

            UpdateList();

            this.Show();
        }

        private void UpdateList()
        {

            listView1.Items.Clear();

            for (int i = 0; i < _drivers.Count(); ++i)
            {
                Driver driver = _drivers[i];

                string GoKart = driver.GoKart.ToString();
                string FirstName = driver.FirstName;
                string LastName = driver.LastName;
                string Points = driver.Points.ToString();

                ListViewItem lvt = new ListViewItem((i + 1).ToString() + ".");

                lvt.SubItems.Add(FirstName);
                lvt.SubItems.Add(LastName);
                lvt.SubItems.Add(GoKart);
                lvt.SubItems.Add(Points);

                listView1.Items.Add(lvt);

            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateView()
        {

            _drivers = Standings.GetStandings(_driverRepository.GetAllDrivers());

            UpdateList();

        }

        private void formViewStandings_FormClosing(object sender, FormClosingEventArgs e)
        {
            _driverRepository.DeleteObserver(this);
            _raceRepository.DeleteObserver(this);
        }

    }
}
