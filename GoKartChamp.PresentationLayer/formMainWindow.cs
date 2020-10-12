using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GoKartChamp.Controllers;
using GoKartChamp.Model;

namespace GoKartChamp.PresentationLayer
{
    public partial class formMainWindow : Form
    {

        private readonly MainController _controller;

        public formMainWindow(MainController inMainController)
        {
            _controller = inMainController;

            InitializeComponent();

        }

        private void viewDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ViewDrivers();
        }

        private void addDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.AddDriver();
        }

        private void AddTracksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.AddTrack();
        }

        private void viewTracksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ViewTracks();
        }

        private void AddRacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.AddRace();
        }

        private void viewUpcomingRacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ViewUpcomingRaces();
        }

        private void viewFinishedRacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ViewFinishedRaces();
        }

        private void viewStandingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ViewStandings();
        }



    }
}
