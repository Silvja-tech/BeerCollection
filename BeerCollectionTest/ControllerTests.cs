using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace BeerCollectionTest
{
    public class ControllerTests
    {
        [Fact]
        public void GetAllBeers_ReturnsOkObjectResult_WhenServiceSucceeds()
        {
            // Arrange
            var mockBeerService = new Mock<IBeerService>();
            var controller = new BeerController(mockBeerService.Object);

            // Act
            var result = controller.GetAllBeers();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetAllBeers_ReturnsInternalServerError_WhenServiceThrowsException()
        {
            // Arrange
            var mockBeerService = new Mock<IBeerService>();
            mockBeerService.Setup(service => service.GetAllBeers()).Throws(new Exception("Mock exception"));

            var controller = new BeerController(mockBeerService.Object);

            // Act
            var result = controller.GetAllBeers();

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Equal("An error occurred while getting data with message:Mock exception", statusCodeResult.StatusDescription);
        }
    }
}

