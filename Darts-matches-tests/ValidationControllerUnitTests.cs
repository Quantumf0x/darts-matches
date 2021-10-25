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
        public void StringInputValidateTest()
        {
            var result = ValidationController.Instance.StringInputValidate(string.Empty);
            var resultErrorContent = result.ErrorContent;
            string expected = "You cannot leave the field empty";

            Assert.AreEqual(expected, resultErrorContent);
        }

        [TestMethod]
        public void MatchDateValidateTest()
        {
            var date = new DateTime(2008, 3, 1);
            var result = ValidationController.Instance.MatchDateValidate(date);
            var resultErrorContent = result.ErrorContent;

            string expected = null;

            Assert.AreEqual(expected, resultErrorContent);
        }

        [TestMethod]
        public void SetsAndLegValidateTest()
        {
            var result = ValidationController.Instance.SetsAndLegValidate("0");
            var resultErrorContent = result.ErrorContent;

            string expected = "Number of sets must be 1 or higher";

            Assert.AreEqual(expected, resultErrorContent);
        }
    }
}
