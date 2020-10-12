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
    public partial class formEditRace : Form, IEditRaceView
    {
        public formEditRace()
        {
            InitializeComponent();
        }

        public string RaceName => textBoxName.Text;

        public DateTime RaceDate => dateTimePicker.Value.Date;

        public string RaceTrackName
        {
            get
            {

                try
                {
                    return comboBoxTrack.SelectedItem.ToString();

                }
                catch (Exception)
                {                   
                    return null;
                }

            }
        }

        public int ShowViewModal(List<Track> tracks, Race race)
        {

            System.Object[] itemObject = new System.Object[tracks.Count()];
            for (int i = 0; i < tracks.Count(); ++i)
            {
                itemObject[i] = tracks[i].Name;
            }

            comboBoxTrack.Items.AddRange(itemObject);

            textBoxName.Text = race.Name;
            comboBoxTrack.Text = race.Track.Name;
            dateTimePicker.Value = race.Date;

            DialogResult result = this.ShowDialog();

            if (result == DialogResult.OK) return 1;
            else if (result == DialogResult.Abort) return 2;
            else return 3;
        }
    }
}
