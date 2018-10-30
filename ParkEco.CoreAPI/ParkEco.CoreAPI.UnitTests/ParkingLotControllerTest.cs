using Moq;
using ParkEco.CoreAPI.Controllers;
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
    }
}
