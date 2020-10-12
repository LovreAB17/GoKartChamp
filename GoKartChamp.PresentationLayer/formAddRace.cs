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
    public partial class formAddRace : Form, IAddRaceView
    {

        public formAddRace()
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

                } catch (Exception)
                {
                    return null;
                }
               
            }
        }

        public bool ShowViewModal(List<Track> tracks)
        {
            System.Object[] itemObject = new System.Object[tracks.Count()];
            for(int i = 0; i < tracks.Count(); ++i)
            {
                itemObject[i] = tracks[i].Name;
            }

            comboBoxTrack.Items.AddRange(itemObject);


            if (this.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
