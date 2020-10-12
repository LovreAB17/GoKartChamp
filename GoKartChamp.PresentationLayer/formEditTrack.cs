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
    public partial class formEditTrack : Form, IEditTrackView
    {
        public formEditTrack()
        {
            InitializeComponent();
        }

        public string TrackName => textBoxName.Text;

        public int Length
        {
            get
            {
                int lentgh = 0;

                if (Int32.TryParse(textBoxLength.Text, out lentgh) == true)
                {
                    return lentgh;
                }

                return -1;
            }
        }



        public int ShowViewModal(Track track)
        {

            textBoxName.Text = track.Name;
            labelLocation.Text = track.Location;
            textBoxLength.Text = track.Length.ToString();

            DialogResult result = this.ShowDialog();

            if (result == DialogResult.OK) return 1;
            else if (result == DialogResult.Abort) return 2;
            else return 3;

        }
    }
}
