using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoKartChamp.MemBasedDAL;
using GoKartChamp.Model;
using GoKartChamp.BaseLib.Exceptions;

namespace GoKartChamp.UnitTests
{
    [TestClass]
    public class DriverTests
    {
        [TestInitialize]
        public void ReInitializeDriverRepository()
        {

            System.Reflection.FieldInfo fi = typeof(DriverRepository).GetField("_instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Assert.IsNotNull(fi);

            fi.SetValue(null, null);

        }

        [TestMethod]
        public void Test_AddDriver()
        {

            DriverRepository driverRepository = DriverRepository.GetInstance();

            Driver driver = new Driver(44, "Lewis", "Hamilton");

            driverRepository.AddDriver(driver);

            Driver dri = driverRepository.GetDriverByGoKart(44);
            Assert.IsInstanceOfType(dri, typeof(Driver));

            Driver dri2 = driverRepository.GetDriverByName("Lewis", "Hamilton");
            Assert.IsInstanceOfType(dri2, typeof(Driver));

            Assert.AreEqual(0, dri2.Points);

        }

        [TestMethod]
        [ExpectedException(typeof(MaxNumberOfDriversException))]
        public void Test_MaximumNumberOfDriversExceeded()
        {

            DriverRepository driverRepository = DriverRepository.GetInstance();

            for(int i = 1; i < 22; ++i)
            {

                driverRepository.AddDriver(new Driver(i, "Nije", "Bitno"));

            }

        }



        [TestMethod]
        public void Test_AddPoints()
        {

            DriverRepository driverRepository = DriverRepository.GetInstance();

            Driver driver = new Driver(16, "Charles", "Leclerc");

            driverRepository.AddDriver(driver);

            Driver dri = driverRepository.GetDriverByGoKart(16);
            Assert.AreEqual(0, dri.Points);

            driverRepository.AddPoints(16, 25);

            Driver dri2 = driverRepository.GetDriverByGoKart(16);
            Assert.AreEqual(25, dri2.Points);

            driverRepository.AddPoints(16, 10);

            dri2 = driverRepository.GetDriverByGoKart(16);
            Assert.AreEqual(35, dri2.Points);

        }

        [TestMethod]
        [ExpectedException(typeof(DriverAlreadyExistsException))]
        public void Test_AddingSameDriverReferenceTwice()
        {

            DriverRepository driverRepository = DriverRepository.GetInstance();

            Driver driver = new Driver(5, "Sebastian", "Vettel");

            driverRepository.AddDriver(driver);
            driverRepository.AddDriver(driver);

        }

        [TestMethod]
        [ExpectedException(typeof(DriverAlreadyExistsException))]
        public void Test_AddTwoDriversWithSameGoKartNumber()
        {

            DriverRepository driverRepository = DriverRepository.GetInstance();

            Driver driver1 = new Driver(5, "Sebastian", "Vettel");
            Driver driver2 = new Driver(5, "Carlos", "Seinz");


            driverRepository.AddDriver(driver1);
            driverRepository.AddDriver(driver1);

        }

        [TestMethod]
        public void Test_EditDriver()
        {

            DriverRepository driverRepository = DriverRepository.GetInstance();

            Driver driver = new Driver(5, "Sebastian", "Vettel");

            driverRepository.AddDriver(driver);

            driverRepository.UpdateDriver(5, "Carlos", "Seinz");

            Driver update = driverRepository.GetDriverByGoKart(5);

            Assert.AreEqual("Carlos", update.FirstName);
            Assert.AreEqual("Seinz", update.LastName);

        }

        [TestMethod]
        public void Test_RemoveDriver()
        {

            DriverRepository driverRepository = DriverRepository.GetInstance();

            Driver driver = new Driver(5, "Sebastian", "Vettel");

            driverRepository.AddDriver(driver);

            driverRepository.RemoveDriver(5);

            Driver removed = driverRepository.GetDriverByGoKart(5);

            Assert.IsFalse(removed.Active);

        }

        [TestMethod]
        [ExpectedException(typeof(DriverNotFoundException))]
        public void Test_GetDriverByGoKart_DriverNotFound()
        {

            DriverRepository driverRepository = DriverRepository.GetInstance();

            Driver driver = driverRepository.GetDriverByGoKart(2);

        }

        [TestMethod]
        public void Test_FirstPlaceInStandings()
        {

            DriverRepository driverRepository = DriverRepository.GetInstance();

            driverRepository.AddDriver(new Driver(16, "Charles", "Leclerc"));
            driverRepository.AddDriver(new Driver(5, "Sebastian", "Vettel"));
            driverRepository.AddDriver(new Driver(44, "Lewis", "Hamilton"));
            driverRepository.AddDriver(new Driver(77, "Valteri", "Bottas"));
            driverRepository.AddDriver(new Driver(3, "Max", "Verstapen"));
            driverRepository.AddDriver(new Driver(55, "Carlos", "Seinz"));

            driverRepository.AddPoints(16, 10);
            driverRepository.AddPoints(5, 15);
            driverRepository.AddPoints(44, 20);
            driverRepository.AddPoints(77, 12);
            driverRepository.AddPoints(3, 10);

            Driver best = Standings.GetStandings(driverRepository.GetAllActiveDrivers())[0];

            Assert.AreEqual(44, best.GoKart);

        }



    }
}
