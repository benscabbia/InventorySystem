using InventorySystem.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace InventorySystem.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ItemController controller = new ItemController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            ItemController controller = new ItemController();

            // Act
            //ViewResult result = controller.About() as ViewResult;

            // Assert
            //Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            ItemController controller = new ItemController();

            // Act
            //ViewResult result = controller.Contact() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
        }
    }
}
