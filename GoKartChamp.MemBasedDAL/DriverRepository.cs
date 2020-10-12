using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GoKartChamp.BaseLib;
using GoKartChamp.BaseLib.Exceptions;
using GoKartChamp.Model.Repositories;
using GoKartChamp.Model;

namespace GoKartChamp.MemBasedDAL
{
    public class DriverRepository : Subject, IDriverRepository
    {

        private List<Driver> _drivers = new List<Driver>();

        private static  DriverRepository _instance;

        public static DriverRepository GetInstance()
        {
            return _instance ?? (_instance = new DriverRepository());
        }


        public void AddDriver(Driver driver)
        {

            if (_drivers.Any(dri => dri.GoKart == driver.GoKart))
            {
                throw new DriverAlreadyExistsException();
            }

            if(_drivers.Count() >= 20)
            {
                throw new MaxNumberOfDriversException();
            }

            _drivers.Add(driver);

            NotifyObservers();
        }

        public void UpdateDriver(int inGoKart, string inNewFirstName, string inNewLastName)
        {

            var dri = _drivers.Find(d => d.GoKart == inGoKart);

            if (dri != null)
            {
                dri.FirstName = inNewFirstName;
                dri.LastName = inNewLastName;
                NotifyObservers();
                return;
            }

            throw new DriverNotFoundException();

        }

        public void RemoveDriver(int inGoKart)
        {

            var dri = _drivers.Find(d => d.GoKart == inGoKart);

            if (dri != null)
            {
                dri.Active = false;
                NotifyObservers();
                return;
            }

            throw new DriverNotFoundException();

        }

        public bool IsActiveByGoKart(int inGoKart)
        {
            var dri = _drivers.Find(d => d.GoKart == inGoKart);

            if (dri != null)
            {
                return dri.Active;
            }

            throw new DriverNotFoundException();
        }

        public Driver GetDriverByGoKart(int inGoKart)
        {
            var dri = _drivers.Find(d => d.GoKart == inGoKart);

            if (dri != null)
            {
                return dri;
            }

            throw new DriverNotFoundException();

        }

        public Driver GetDriverByName(string inFirstName, string inLastName)
        {
            var dri = _drivers.Find(d => (d.FirstName == inFirstName && d.LastName == inLastName));

            if (dri != null)
            {
                return dri;
            }

            throw new DriverNotFoundException();

        }

        public List<Driver> GetAllDrivers()
        {
            return _drivers;
        }


        public List<Driver> GetAllActiveDrivers()
        {

            return _drivers.Where(a => a.Active).ToList();

        }

        public Driver AddPoints(int inGoKart, int inPoints)
        {
            var dri = _drivers.Find(d => d.GoKart == inGoKart);

            if (dri != null)
            {
                dri.Points += inPoints;
                return dri;
            }

            throw new DriverNotFoundException();
        }

        public int NumberOfDrivers()
        {
            return _drivers.Count;
        }


    }
}
