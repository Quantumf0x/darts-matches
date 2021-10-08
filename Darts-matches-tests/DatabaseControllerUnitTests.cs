using Microsoft.VisualStudio.TestTools.UnitTesting;
using Darts_matches;

namespace Darts_matches_tests
{
    [TestClass]
    public class DatabaseControllerUnitTests
    {
        [TestMethod]
        public void TestConnectionOpen()
        {
            //arrange
            Darts_matches.Controllers.DatabaseController dbManager = Darts_matches.Controllers.DatabaseController.GetInstance();
            string expected = "Open";

            //act
            dbManager.TestConnection();

            //assert
            string state = dbManager.GetState1();
            Assert.AreEqual(expected, state, "connection not established: " + state);
        }

        [TestMethod]
        public void TestConnectionClose()
        {
            //arrange
            Darts_matches.Controllers.DatabaseController dbManager = Darts_matches.Controllers.DatabaseController.GetInstance();
            string expected = "Closed";

            //act
            dbManager.TestConnection();

            //assert
            string state = dbManager.GetState2();
            Assert.AreEqual(expected, state, "connection not established: " + state);
        }

        [TestMethod]
        public void TestDatabaseInsert()
        {
            //arrange
            Darts_matches.Controllers.DatabaseController dbManager = Darts_matches.Controllers.DatabaseController.GetInstance();
            bool expected = true;

            //act
            dbManager.AddToDatabase("dutch-open", "test", 501, "tester1", "tester1", "tester2", "1:2:2:1:2", "2:3:1:3:0", "2:3:1:3:0", 23, 43, "130:70:100", "130:70:100", "105:101:80;90:80", "105:101:80;90:80", 5, 1, System.DateTime.Today);

            //assert
            bool succes = dbManager.GetSucces();
            Assert.AreEqual(expected, succes, "data not inserted into database");
        }
    }
}
