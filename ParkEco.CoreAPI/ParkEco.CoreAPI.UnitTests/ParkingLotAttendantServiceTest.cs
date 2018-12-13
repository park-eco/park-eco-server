using Moq;
using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using ParkEco.CoreAPI.Services.Implementations;
using ParkEco.CoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParkEco.CoreAPI.UnitTests
{
    public class ParkingLotAttendantServiceTest
    {
        [Fact]
        public void GetAll_ShouldReturnAllUsers()
        {
            var mockParkingLotAttendantRepository = new Mock<IParkingLotAttendantRepository>();
            List<ParkingLotAttendant> expectedList = new List<ParkingLotAttendant>()
            {
                new ParkingLotAttendant()
                {
                    Id = Guid.NewGuid(),
                    Email = "email01",
                    Name = "name01",
                    Password = "password01",
                    PhoneNumber = "0101",
                    Username = "username01",
                    Tickets = new List<Ticket>()
                },
                new ParkingLotAttendant()
                {
                    Id = Guid.NewGuid(),
                    Email = "email02",
                    Name = "name02",
                    Password = "password02",
                    PhoneNumber = "0202",
                    Username = "username02",
                    Tickets = new List<Ticket>()
                }
            };
            mockParkingLotAttendantRepository.Setup(repo => repo.GetAll()).Returns(expectedList);

            var service = new ParkingLotAttendantService(mockParkingLotAttendantRepository.Object);
            var actualList = (service as IParkingLotAttendantService).GetAll();

            Assert.Equal(expectedList, actualList);
        }

        [Fact]
        public void Get_ShouldReturnCorrectUser_WhenGivenExistingUsername()
        {
            var mockParkingLotAttendantRepository = new Mock<IParkingLotAttendantRepository>();
            var expectedUser = new ParkingLotAttendant()
            {
                Id = Guid.NewGuid(),
                Email = "email01",
                Name = "name01",
                Password = "password01",
                PhoneNumber = "0101",
                Username = "username01",
                Tickets = new List<Ticket>()
            };

            mockParkingLotAttendantRepository.Setup(repo => repo.Get(It.Is<string>(val => val == expectedUser.Username)))
            .Returns(expectedUser);

            var service = new ParkingLotAttendantService(mockParkingLotAttendantRepository.Object);
            var actualUser = (service as IParkingLotAttendantService).Get(expectedUser.Username);

            Assert.Equal(expectedUser, actualUser);
        }
    }
}
