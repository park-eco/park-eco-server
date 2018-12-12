using Microsoft.AspNetCore.Http;
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

        [Fact]
        public void CreateNewSession_ShouldReturn500_WhenCreateMethodThrows()
        {
            var mockSessionService = new Mock<ISessionService>();
            Guid expectedGuid = Guid.NewGuid();
            DateTime expectedFrom = new DateTime();
            DateTime expectedTo = new DateTime();
            mockSessionService.Setup(service =>
                service.Create(It.Is<DateTime>(value => value == expectedFrom),
                    It.Is<DateTime>(value => value == expectedTo),
                    It.Is<Guid>(value => value == expectedGuid)))
                .Throws(new Exception());

            var controller = new SessionsController(mockSessionService.Object);
            var result = controller.CreateNewSession(new Controllers.Models.CreateNewSessionCommand()
            {
                From = expectedFrom,
                To = expectedTo,
                ParkingLotId = expectedGuid
            }) as Microsoft.AspNetCore.Mvc.StatusCodeResult;

            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }

        [Fact]
        public void DeleteSession_ShouldCallDeleteMethodInService()
        {
            var mockSessionService = new Mock<ISessionService>();
            Guid expectedGuid = Guid.NewGuid();
            mockSessionService.Setup(service =>
                service.Delete(It.Is<Guid>(value => value == expectedGuid)))
                .Verifiable();

            var controller = new SessionsController(mockSessionService.Object);
            var result = controller.DeleteSession(expectedGuid);

            mockSessionService.Verify(service =>
                service.Delete(
                    It.Is<Guid>(value => value == expectedGuid)
                ),
                Times.Once);
        }

        [Fact]
        public void DeleteSession_ShouldReturn500_WhenDeleteMethodThrows()
        {
            var mockSessionService = new Mock<ISessionService>();
            Guid expectedGuid = Guid.NewGuid();
            mockSessionService.Setup(service =>
                service.Delete(It.Is<Guid>(value => value == expectedGuid)))
                .Throws(new Exception());

            var controller = new SessionsController(mockSessionService.Object);
            var result = controller.DeleteSession(expectedGuid) 
                as Microsoft.AspNetCore.Mvc.StatusCodeResult;

            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
        }
    }
}
