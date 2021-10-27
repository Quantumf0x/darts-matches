using Microsoft.VisualStudio.TestTools.UnitTesting;
using Darts_matches;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data;

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

        [TestMethod]
        public void TestDataBasePull1()
        {
            //arrange
            Darts_matches.Controllers.DatabaseController dbManager = Darts_matches.Controllers.DatabaseController.GetInstance();
            string _value1 = "frisian-open";
            int _value2 = 501;
            string _value3 = "105:101:80;80:30:50;40:60:50";
            string _value4 = "25/10/2021 00:00:00";

            //act
            DataTable _dataList = new DataTable();
            _dataList = dbManager.PullAllFromDatabase();

            //assert
            Trace.WriteLine(_dataList.Rows[0][1]);
            Trace.WriteLine(_dataList.Rows[1][3]);
            Trace.WriteLine(_dataList.Rows[2][14]);
            Trace.WriteLine(_dataList.Rows[2][18]);
            Assert.AreEqual(_value1, _dataList.Rows[0][1], "data niet gelijk");
            Assert.AreEqual(_value2, _dataList.Rows[1][3], "data niet gelijk");
            Assert.AreEqual(_value3, _dataList.Rows[2][14], "data niet gelijk");
            Assert.AreEqual(_value4, _dataList.Rows[2][18].ToString(), "datum niet gelijk");
        }
    }
}
