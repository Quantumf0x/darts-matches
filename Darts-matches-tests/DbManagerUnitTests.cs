using Microsoft.VisualStudio.TestTools.UnitTesting;
using Darts_matches;

namespace Darts_matches_tests
{
    [TestClass]
    public class DbManagerUnitTests
    {
        [TestMethod]
        public void TestConnectionOpen()
        {
            //arrange
            Darts_matches.DbManager dbManager = Darts_matches.DbManager.getInstance();
            string expected = "Open";

            //act
            dbManager.testConnection();

            //assert
            string state = dbManager.getState1();
            Assert.AreEqual(expected, state, "connection not established: " + state);
        }

        [TestMethod]
        public void TestConnectionClose()
        {
            //arrange
            Darts_matches.DbManager dbManager = Darts_matches.DbManager.getInstance();
            string expected = "Closed";

            //act
            dbManager.testConnection();

            //assert
            string state = dbManager.getState2();
            Assert.AreEqual(expected, state, "connection not established: " + state);
        }

        [TestMethod]
        public void TestDatabaseInsert()
        {
            //arrange
            Darts_matches.DbManager dbManager = Darts_matches.DbManager.getInstance();
            bool expected = true;

            //act
            dbManager.addToDatabase("test", "test", "test", "tester1", "tester2", "011001", "test", "test", 23, 43, "test", "test", "test", "test", 5, 1, System.DateTime.Today);

            //assert
            bool succes = dbManager.getSucces();
            Assert.AreEqual(expected, succes, "data not inserted into database");
        }
    }
}
