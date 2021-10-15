using Microsoft.VisualStudio.TestTools.UnitTesting;
using Darts_matches;
using System.Diagnostics;
using System;
using System.Collections.Generic;

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
            string state = dbManager.GetTestConnectionOpen();
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
            string state = dbManager.GetTestConnectionClose();
            Assert.AreEqual(expected, state, "connection not established: " + state);
        }

        //[TestMethod]
        public void TestDatabaseInsert()
        {
            //arrange
            Darts_matches.Controllers.DatabaseController dbManager = Darts_matches.Controllers.DatabaseController.GetInstance();
            bool expected = true;

            //act
            dbManager.AddToDatabase("dutch-open", "test", 501, "tester1", "tester1", "tester2", "1:2:2:1:2", "2:3:1:3:0", "2:3:1:3:0", 23, 43, "130:70:100", "130:70:100", "105:101:80;90:80", "105:101:80;90:80", 5, 1, DateTime.Now);

            //assert
            bool succes = dbManager.GetSucces();
            Assert.AreEqual(expected, succes, "data not inserted into database");
        }

        //[TestMethod]
        public void TestDataBasePull1()
        {
            ////arange
            //Darts_matches.Controllers.DatabaseController dbManager = Darts_matches.Controllers.DatabaseController.GetInstance();
            //string _value1 = "dutch-open";
            //int _value2 = 501;
            //string _value3 = "105:101:80;90:80";
            //string _value4 = "10/08/2021 00:00:00";

            ////act
            //List<object[]> _dataList = new List<object[]>();
            //_dataList = dbManager.PullAllFromDatabase();

            ////assert
            //object[] _dataListValue1 = _dataList[0];
            //object[] _dataListValue2 = _dataList[1];
            //object[] _dataListValue3 = _dataList[2];
            //object[] _dataListValue4 = _dataList[2];
            //Trace.WriteLine(_dataListValue1[1]);
            //Trace.WriteLine(_dataListValue2[3]);
            //Trace.WriteLine(_dataListValue3[14]);
            //Trace.WriteLine(_dataListValue4[18]);
            //Assert.AreEqual(_value1, _dataListValue1[1], "data niet gelijk");
            //Assert.AreEqual(_value2, _dataListValue2[3], "data niet gelijk");
            //Assert.AreEqual(_value3, _dataListValue3[14], "data niet gelijk");
            //Assert.AreEqual(_value4, _dataListValue4[18].ToString(), "datum niet gelijk");
        }
    }
}
