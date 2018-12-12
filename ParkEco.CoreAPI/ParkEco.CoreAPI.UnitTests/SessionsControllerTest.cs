using Moq;
using ParkEco.CoreAPI.Controllers;
using ParkEco.CoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkEco.CoreAPI.UnitTests
{
    public class SessionsControllerTest
    {
        [Fact]
        public void CreateNewSession_ShouldCallCreateMethodInService()
        {
            var mockSessionService = new Mock<ISessionService>();
            Guid expectedGuid = Guid.NewGuid();
            DateTime expectedFrom = new DateTime();
            DateTime expectedTo = new DateTime();
            mockSessionService.Setup(service =>
                service.Create(It.Is<DateTime>(value => value == expectedFrom),
                    It.Is<DateTime>(value => value == expectedTo),
                    It.Is<Guid>(value => value == expectedGuid)))
                .Verifiable();

            var controller = new SessionsController(mockSessionService.Object);
            var result = controller.CreateNewSession(new Controllers.Models.CreateNewSessionCommand()
            {
                From = expectedFrom,
                To = expectedTo,
                ParkingLotId = expectedGuid
            });

            mockSessionService.Verify(service =>
                service.Create(
                    It.Is<DateTime>(value => value == expectedFrom),
                    It.Is<DateTime>(value => value == expectedTo),
                    It.Is<Guid>(value => value == expectedGuid)
                ),
                Times.Once);
        }
    }
}
