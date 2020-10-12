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
    public partial class formEditDriver : Form, IEditDriverView
    {
        public formEditDriver()
        {
            InitializeComponent();
        }

        public string DriverFirstName => textBoxFirstName.Text;
        public string DriverLastName => textBoxLastName.Text;

        public int ShowViewModal(Driver driver)
        {
            labelID.Text = driver.GoKart.ToString();
            textBoxFirstName.Text = driver.FirstName;
            textBoxLastName.Text = driver.LastName;

            DialogResult result = this.ShowDialog();

            if (result == DialogResult.OK) return 1;
            else if (result == DialogResult.Abort) return 2;
            else return 3;

        }
    }
}
