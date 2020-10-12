using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GoKartChamp.BaseLib;
using GoKartChamp.BaseLib.Exceptions;
using GoKartChamp.MemBasedDAL;
using GoKartChamp.Model;
using GoKartChamp.Model.Factories;

namespace GoKartChamp.Controllers
{
    public class DriverController
    {

        public void AddDriver(IAddDriverView inForm)
        {
            DriverRepository _driverRepository = DriverRepository.GetInstance();

            if (inForm.ShowViewModal() == true)
            {
                try
                {
                    string FirstName = inForm.DriverFirstName;
                    if (string.IsNullOrEmpty(FirstName)) throw new ArgumentException("First name is not selected!");

                    string LastName = inForm.DriverLastName;
                    if (string.IsNullOrEmpty(LastName)) throw new ArgumentException("Last name is not selected!");

                    int GoKart = inForm.DriverGoKart;

                    if (GoKart < 0)
                    {
                        throw new ArgumentException("GoKart value is not supported!");
                    }

                    Driver newDriver = DriverFactory.CreateDriver(GoKart, FirstName, LastName);

                    _driverRepository.AddDriver(newDriver);

                }
                catch (DriverAlreadyExistsException)
                {
                    MessageBox.Show("Go Kart number is already taken! Choose another one");
                }
                catch (MaxNumberOfDriversException)
                {
                    MessageBox.Show("The maximum number of drivers in the championship is exceeded");
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

        }

        public void ViewDrivers(IMainController _mainController, IShowDriversView inForm)
        {

            DriverRepository _driverRepository = DriverRepository.GetInstance();

            List<Driver> drivers = _driverRepository.GetAllActiveDrivers();

            inForm.ShowModaless(_mainController, drivers);

        }

        public void ViewStandings(IShowStandingsView inForm)
        {
            DriverRepository _driverRepository = DriverRepository.GetInstance();

            List<Driver> sortedDrivers = Standings.GetStandings(_driverRepository.GetAllDrivers());

            inForm.ShowModaless(sortedDrivers);
        }


        public void EditDriver(IEditDriverView inForm , int driverGoKart)
        {

            DriverRepository _driverRepository = DriverRepository.GetInstance();

            try
            {

                Driver driver = _driverRepository.GetDriverByGoKart(driverGoKart);

                int result = inForm.ShowViewModal(driver);


                if (result == 1)
                {

                    string FirstName = inForm.DriverFirstName;
                    if (string.IsNullOrEmpty(FirstName)) throw new ArgumentException("First name is not selected!");

                    string LastName = inForm.DriverLastName;
                    if (string.IsNullOrEmpty(FirstName)) throw new ArgumentException("Last name is not selected!");

                    _driverRepository.UpdateDriver(driverGoKart, FirstName, LastName);
                }
                else if (result == 2)
                {
                    _driverRepository.RemoveDriver(driverGoKart);
                }

            }
            catch (DriverNotFoundException)
            {
                MessageBox.Show("Chosen driver not found!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



    }
}
