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


namespace GoKartChamp.PresentationLayer
{
    public partial class formAddTrack : Form, IAddTrackView
    {
        public formAddTrack()
        {
            InitializeComponent();
        }

        public string TrackName => textBoxName.Text;

        public string TrackLocation => textBoxLocation.Text;

        public int TrackLength
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


        public bool ShowViewModal()
        {
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
