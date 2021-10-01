using Microsoft.VisualStudio.TestTools.UnitTesting;
using Darts_matches;

namespace Darts_matches_tests
{
    [TestClass]
    public class DbManagerUnitTests
    {
        [TestMethod]
        public void TestConnection()
        {
            //arrange
            Darts_matches.DbManager dbManager = Darts_matches.DbManager.getInstance();
            string expected = "Open";

            //act
            dbManager.addToDatabase();

            //assert
            string state = dbManager.getState();
            Assert.AreEqual(expected, state, "connection not established: " + state);
        }
    }
}
