using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMatch.Common.Messages;
using TextMatch.Controllers;
using TextMatch.Models;

namespace TextMatch.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests : BaseControllerTests
    {
        public HomeController ControllerToTest { get; set; }
        public StringMatchModel ModelToTest { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            ControllerToTest = new HomeController();
            ModelToTest = new StringMatchModel();
        }

        [TestMethod]
        public void Index()
        {
            // Act
            var result = ControllerToTest.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Match_Should_Check_ModelState()
        {
            ControllerToTest.ModelState.AddModelError("fakeError", "fakeError");

            var result = ControllerToTest.Match(ModelToTest) as ViewResult;

            Assert.IsTrue(ModelToTest.HasError);
            Assert.AreEqual(ErrorResource.ModelState_NotValid, ModelToTest.ErrorMessage);
        }
    }
}