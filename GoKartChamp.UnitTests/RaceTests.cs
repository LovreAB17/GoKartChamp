using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoKartChamp.MemBasedDAL;
using GoKartChamp.Model;
using GoKartChamp.BaseLib.Exceptions;
using System.Collections.Generic;

namespace GoKartChamp.UnitTests
{
    [TestClass]
    public class RaceTests
    {

        DriverRepository driverRepository;
        TrackRepository trackRepository;


        [TestInitialize]
        public void ReInitializeDriverRepository()
        {

            System.Reflection.FieldInfo fi0 = typeof(DriverRepository).GetField("_instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Assert.IsNotNull(fi0);

            fi0.SetValue(null, null);

            System.Reflection.FieldInfo fi1 = typeof(TrackRepository).GetField("_instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Assert.IsNotNull(fi1);

            fi1.SetValue(null, null);

            System.Reflection.FieldInfo fi2 = typeof(RaceRepository).GetField("_instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Assert.IsNotNull(fi2);

            fi2.SetValue(null, null);



            driverRepository = DriverRepository.GetInstance();
            driverRepository.AddDriver(new Driver(16, "Charles", "Leclerc"));
            driverRepository.AddDriver(new Driver(5, "Sebastian", "Vettel"));
            driverRepository.AddDriver(new Driver(44, "Lewis", "Hamilton"));
            driverRepository.AddDriver(new Driver(77, "Valteri", "Bottas"));
            driverRepository.AddDriver(new Driver(3, "Max", "Verstapen"));
            driverRepository.AddDriver(new Driver(55, "Carlos", "Seinz"));

            trackRepository = TrackRepository.GetInstance();
            trackRepository.AddTrack(new Track(1, "Melbourne Grand Prix Circuit", "Australia", 5303000));
            trackRepository.AddTrack(new Track(2, "Bahrein International Circuit", "Bahrein", 5412000));
            trackRepository.AddTrack(new Track(3, "Spa-Francorchhamps", "Belgium", 7004000));
            trackRepository.AddTrack(new Track(4, "Shangai International Circuit", "China", 5451000));

        }

        [TestMethod]
        public void Test_AddRace()
        {

            RaceRepository raceRepository = RaceRepository.GetInstance();

            Race race = new Race(raceRepository.GetNewID(), "AusGP", new DateTime(2020, 3, 15), trackRepository.GetTrackByName("Melbourne Grand Prix Circuit"));

            raceRepository.AddRace(race);

            Race getRace = raceRepository.GetRaceByName("AusGP");

            Assert.IsInstanceOfType(getRace, typeof(Race));

        }

        [TestMethod]
        public void Test_EnterRaceResults()
        {

            RaceRepository raceRepository = RaceRepository.GetInstance();

            Race race = new Race(raceRepository.GetNewID(), "AusGP", new DateTime(2020, 3, 15), trackRepository.GetTrackByName("Melbourne Grand Prix Circuit"));

            raceRepository.AddRace(race);

            RaceResults raceResults = new RaceResults(driverRepository.GetAllActiveDrivers(), driverRepository.GetDriverByGoKart(16));

            raceRepository.EnterResults("AusGP", raceResults);

            Assert.IsTrue(raceRepository.GetRaceByName("AusGP").Finished);

        }

        [TestMethod]
        [ExpectedException(typeof(RaceNotFoundException))]
        public void Test_EnterRaceResultsToNonExistingRace()
        {

            RaceRepository raceRepository = RaceRepository.GetInstance();

            RaceResults raceResults = new RaceResults(driverRepository.GetAllActiveDrivers(), driverRepository.GetDriverByGoKart(16));

            raceRepository.EnterResults("AusGP", raceResults);

        }

        [TestMethod]
        public void Test_GetDriverWithFastestLapInRace()
        {

            RaceRepository raceRepository = RaceRepository.GetInstance();

            Race race = new Race(raceRepository.GetNewID(), "BahGP", new DateTime(2020, 3, 22), trackRepository.GetTrackByName("Bahrein International Circuit"));

            raceRepository.AddRace(race);

            RaceResults raceResults = new RaceResults(driverRepository.GetAllActiveDrivers(), driverRepository.GetDriverByGoKart(5));

            raceRepository.EnterResults("BahGP", raceResults);

            Race getRace = raceRepository.GetRaceByName("BahGP");

            Assert.AreEqual(5, getRace.Results.FastestLap.GoKart);

        }

        [TestMethod]
        [ExpectedException(typeof(RaceAlreadyFinishedException))]
        public void Test_TryToRemoveFinishedRace()
        {

            RaceRepository raceRepository = RaceRepository.GetInstance();

            Race race = new Race(raceRepository.GetNewID(), "BelGP", new DateTime(2020, 3, 22), trackRepository.GetTrackByName("Spa-Francorchhamps"));

            raceRepository.AddRace(race);

            RaceResults raceResults = new RaceResults(driverRepository.GetAllActiveDrivers(), driverRepository.GetDriverByGoKart(5));

            raceRepository.EnterResults("BelGP", raceResults);

            raceRepository.RemoveRace(raceRepository.GetRaceByName("BelGP"));

        }

        [TestMethod]
        [ExpectedException(typeof(RaceAlreadyExistsException))]
        public void Test_AddingSameRaceReferenceTwice()
        {

            RaceRepository raceRepository = RaceRepository.GetInstance();

            Race race = new Race(raceRepository.GetNewID(), "BahGP", new DateTime(2020, 3, 22), trackRepository.GetTrackByName("Bahrein International Circuit"));

            raceRepository.AddRace(race);
            raceRepository.AddRace(race);

        }

        [TestMethod]
        [ExpectedException(typeof(RaceAlreadyExistsException))]
        public void Test_AddTwoRacesWithSameName()
        {

            RaceRepository raceRepository = RaceRepository.GetInstance();

            Race race1 = new Race(raceRepository.GetNewID(), "BahGP", new DateTime(2020, 3, 22), trackRepository.GetTrackByName("Bahrein International Circuit"));
            Race race2 = new Race(raceRepository.GetNewID(), "BahGP", new DateTime(2020, 3, 15), trackRepository.GetTrackByName("Melbourne Grand Prix Circuit"));


            raceRepository.AddRace(race1);
            raceRepository.AddRace(race2);

        }

        [TestMethod]
        public void Test_EditRace()
        {

            RaceRepository raceRepository = RaceRepository.GetInstance();

            Race race = new Race(raceRepository.GetNewID(), "AusGP", new DateTime(2020, 3, 15), trackRepository.GetTrackByName("Melbourne Grand Prix Circuit"));

            raceRepository.AddRace(race);

            raceRepository.UpdateRace(race.ID, "Nova utrka", new DateTime(2903, 1, 23), trackRepository.GetTrackByName("Bahrein International Circuit"));

            Race update = raceRepository.GetRaceByName("Nova utrka");

            Assert.AreEqual("Bahrein", update.Track.Location);

        }













    }
}
