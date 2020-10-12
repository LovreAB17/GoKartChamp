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
    public partial class formEnterResults : Form, IEnterResultsView
    {
        public formEnterResults()
        {
            InitializeComponent();
        }

        public string RaceName
        {
            get
            {

                try
                {
                    return comboBoxRaces.SelectedItem.ToString();

                }
                catch (Exception)
                {
                    return null;
                }

            }
        }

        public string Result => textBoxResults.Text;

        public string FastestLap
        {
            get
            {
                try
                {
                    return comboBoxDrivers.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool ShowViewModal(List<Race> upRaces, List<Driver> activeDrivers)
        {
            System.Object[] itemObject = new System.Object[upRaces.Count()];
            for (int i = 0; i < upRaces.Count(); ++i)
            {
                itemObject[i] = upRaces[i].Name;
            }

            comboBoxRaces.Items.AddRange(itemObject);

            System.Object[] itemObject2 = new System.Object[activeDrivers.Count()];
            for (int i = 0; i < activeDrivers.Count(); ++i)
            {
                itemObject2[i] = activeDrivers[i].GoKart;
            }

            comboBoxDrivers.Items.AddRange(itemObject2);

            for (int i = 0; i < activeDrivers.Count(); ++i)
            {
                Driver driver = activeDrivers[i];

                string GoKart = driver.GoKart.ToString();
                string FirstName = driver.FirstName;
                string LastName = driver.LastName;

                ListViewItem lvt = new ListViewItem(GoKart);
                lvt.SubItems.Add(FirstName);
                lvt.SubItems.Add(LastName);

                listView1.Items.Add(lvt);

            }



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
