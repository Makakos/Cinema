using Cinema.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Cinema.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(null, result.ViewName);
        }

        [Fact]
        public void PrivacyTest()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Privacy() as ViewResult;
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal(null, result.ViewName);
        }
    }
}
