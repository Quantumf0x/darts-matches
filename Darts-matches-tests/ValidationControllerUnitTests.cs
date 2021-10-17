using Darts_matches.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Darts_matches_tests
{
    [TestClass]
    public class ValidationControllerUnitTests
    {
        [TestMethod]
        public void GetErrorMessageTest()
        {
            var result = ValidationController.GetErrorMessage("string");
            string expected = string.Empty;

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public static void StringInputValidateTest()
        {
            var result = ValidationController.Instance.StringInputValidate("string");
            var resultErrorContent = result.ErrorContent;
            string expected = "You cannot leave the field empty";

            Assert.AreEqual(expected, resultErrorContent);
        }
        [TestMethod]
        public static void MatchDateValidateTest()
        {
            var date = new DateTime(2008, 3, 1);
            var result = ValidationController.Instance.MatchDateValidate(date);
            var resultErrorContent = result.ErrorContent;

            string expected = "You cannot leave the datefield empty";

            Assert.AreEqual(expected, resultErrorContent);
        }
        [TestMethod]
        public static void SetsAndLegValidateTest()
        {
            var result = ValidationController.Instance.SetsAndLegValidate("0");
            var resultErrorContent = result.ErrorContent;

            string expected = "error";

            Assert.AreEqual(expected, resultErrorContent);
        }
    }
}
