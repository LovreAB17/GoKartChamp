using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoKartChamp.Model.Repositories
{
    public interface IDriverRepository
    {

        void AddDriver(Driver driver);

        void RemoveDriver(int driver);

        void UpdateDriver(int inGoKart, string inNewFirstName, string inNewLastName);

        List<Driver> GetAllActiveDrivers();

        Driver GetDriverByName(string inFirstName, string inLastName);

        Driver GetDriverByGoKart(int inGoKart);

        bool IsActiveByGoKart(int inGoKart);

        Driver AddPoints(int inGoKart, int inPoints);

        List<Driver> GetAllDrivers();
    }
}
