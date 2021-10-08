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
            dbManager.addToDatabase("dutch-open", "test", "tester1", "tester1", "tester2", "1:2:2:1:2", "2:3:1:3:0", "2:3:1:3:0", 23, 43, "130:70:100", "130:70:100", "105:101:80;90:80", "105:101:80;90:80", 5, 1, System.DateTime.Today);

            //assert
            bool succes = dbManager.getSucces();
            Assert.AreEqual(expected, succes, "data not inserted into database");
        }
    }
}
