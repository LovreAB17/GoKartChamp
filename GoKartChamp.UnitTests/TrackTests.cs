using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoKartChamp.MemBasedDAL;
using GoKartChamp.Model;
using GoKartChamp.BaseLib.Exceptions;

namespace GoKartChamp.UnitTests
{
    [TestClass]
    public class TrackTests
    {

        [TestInitialize]
        public void ReInitializeDriverRepository()
        {

            System.Reflection.FieldInfo fi = typeof(TrackRepository).GetField("_instance", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Assert.IsNotNull(fi);

            fi.SetValue(null, null);

        }

        [TestMethod]
        public void Test_AddTrack()
        {

            TrackRepository trackRepository = TrackRepository.GetInstance();

            Track track = new Track(trackRepository.GetNewID(), "Monza", "Italy", 1000);

            trackRepository.AddTrack(track);

            Track trackTest = trackRepository.GetTrackByName("Monza");

            Assert.IsInstanceOfType(trackTest, typeof(Track));

        }

        [TestMethod]
        [ExpectedException(typeof(TrackAlreadyExistsException))]
        public void Test_AddingSameTrackReferenceTwice()
        {

            TrackRepository trackRepository = TrackRepository.GetInstance();

            Track track = new Track(trackRepository.GetNewID(), "Monza", "Italy", 1000);

            trackRepository.AddTrack(track);
            trackRepository.AddTrack(track);

        }

        [TestMethod]
        public void Test_EditTrack()
        {

            TrackRepository trackRepository = TrackRepository.GetInstance();

            Track track = new Track(trackRepository.GetNewID(), "Spa", "Belgium", 2000);

            trackRepository.AddTrack(track);

            trackRepository.UpdateTrack(track.ID, "Spa2", 14000);

            Track update = trackRepository.GetTrackByName("Spa2");

            Assert.AreEqual("Belgium", update.Location);
            Assert.AreEqual(14000, update.Length);

        }


        [TestMethod]
        public void Test_RemoveTrack()
        {

            TrackRepository trackRepository = TrackRepository.GetInstance();

            Track track = new Track(trackRepository.GetNewID(), "Silverstone", "UK", 20003);

            trackRepository.AddTrack(track);

            trackRepository.RemoveTrack(track);

            Track removed = trackRepository.GetTrackByName("Silverstone");

            Assert.IsFalse(removed.Active);

        }

        [TestMethod]
        [ExpectedException(typeof(TrackNotFoundException))]
        public void Test_GetTrackByName_TrackNotFound()
        {

            TrackRepository trackRepository = TrackRepository.GetInstance();

            Track track = trackRepository.GetTrackByName("Spa");

        }



    }
}
