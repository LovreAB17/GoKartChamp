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
    public partial class formViewDrivers : Form, IShowDriversView, IObserver
    {

        private List<Driver> _drivers = null;
        private IMainController _mainController = null;
        private DriverRepository _driverRepository = null;
    
        public formViewDrivers()
        {
            InitializeComponent();
            _driverRepository = DriverRepository.GetInstance();
        }

        public void ShowModaless(IMainController inMainController, List<Driver> inDrivers)
        {

            _mainController = inMainController;
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

                ListViewItem lvt = new ListViewItem(GoKart);
                lvt.SubItems.Add(FirstName);
                lvt.SubItems.Add(LastName);

                listView1.Items.Add(lvt);

            }
        }

        private void buttonAddDriver_Click(object sender, EventArgs e)
        {
            _mainController.AddDriver();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editDriver_DoubleClick(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count == 1)
            {
                int driverID = Int32.Parse(listView1.SelectedItems[0].Text);
                _mainController.EditDriver(driverID);

            }
            else
            {
                MessageBox.Show("Select only one item!");
            }

        }

        public void UpdateView()
        {

            _drivers = _driverRepository.GetAllActiveDrivers();

            UpdateList();

        }

        private void formViewDrivers_FormClosing(object sender, FormClosingEventArgs e)
        {
            _driverRepository.DeleteObserver(this);
        }
    }
}
