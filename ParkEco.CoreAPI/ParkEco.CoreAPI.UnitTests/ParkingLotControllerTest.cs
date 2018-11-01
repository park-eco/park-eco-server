using Microsoft.AspNetCore.Http;
using Moq;
using ParkEco.CoreAPI.Controllers;
using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkEco.CoreAPI.UnitTests
{
    public class ParkingLotControllerTest
    {
        [Fact]
        public void CreateNewParkingLot_ShouldCallCreateMethodInService()
        {
            var mockParkingLotService = new Mock<IParkingLotService>();
            mockParkingLotService.Setup(service => 
                service
                    .Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())
                )
                .Verifiable();

            var controller = new ParkingLotController(mockParkingLotService.Object);
            var result = controller.CreateNewParkingLot(new Controllers.Models.CreateNewParkingLotCommand()
            {
                Name = "name",
                Address = "address",
                Description = "description"
            });

            mockParkingLotService.Verify(mock => mock.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), 
                Times.Once());
        }

        [Fact]
        public void CreateNewParkingLot_ShouldReturnInternalServerError_WhenInnerThrows()
        {
            var mockParkingLotService = new Mock<IParkingLotService>();
            mockParkingLotService.Setup(service =>
                service
                    .Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())
                )
                .Throws(new Exception());

            var controller = new ParkingLotController(mockParkingLotService.Object);
            var result = controller.CreateNewParkingLot(new Controllers.Models.CreateNewParkingLotCommand()
            {
                Name = "name",
                Address = "address",
                Description = "description"
            }) as Microsoft.AspNetCore.Mvc.StatusCodeResult;
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        [Fact]
        public void GetAll_ShouldCallGetAllMethodInService()
        {
            var mockParkingLotService = new Mock<IParkingLotService>();
            var expectedReturnParkingLot = new List<ParkingLot>()
            {
                new ParkingLot(),
                new ParkingLot()
            };
            mockParkingLotService.Setup(service => service.GetAll()).Returns(expectedReturnParkingLot).Verifiable();

            var controller = new ParkingLotController(mockParkingLotService.Object);
            var result = controller.GetAll();

            Assert.Equal(expectedReturnParkingLot.Count, result.Value.Count);
            mockParkingLotService.Verify(mock => mock.GetAll(), Times.Once);
        }
    }
}
