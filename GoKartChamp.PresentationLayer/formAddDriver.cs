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
    public partial class formAddDriver : Form, IAddDriverView
    {
        public formAddDriver()
        {
            InitializeComponent();
        }

        public int DriverGoKart
        {
            get
            {
                int driverGoKart = -1;

                if (Int32.TryParse(textBoxID.Text, out driverGoKart) == true)
                {

                    if(driverGoKart > 0)
                    {
                        return driverGoKart;
                    }
                }

                return -1;
            }
        }

        public string DriverFirstName => textBoxFirstName.Text;

        public string DriverLastName => textBoxLastName.Text;

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
