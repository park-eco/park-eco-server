using System;
using Xunit;
using Moq;
using ParkEco.CoreAPI.Repositories.Interfaces;
using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Services.Implementations;
using ParkEco.CoreAPI.Services.Interfaces;
using System.Collections.Generic;

namespace ParkEco.CoreAPI.UnitTests
{
    public class ParkingLotServiceTest
    {
        [Fact]
        public void Create_ShouldCallCreateMethodInRepository()
        {
            var mockParkingLotRepository = new Mock<IParkingLotRepository>();
            mockParkingLotRepository.Setup(repo => repo.Create(It.IsAny<ParkingLot>())).Verifiable();

            var service = new ParkingLotService(mockParkingLotRepository.Object);
            (service as IParkingLotService).Create("expected name", "expected address");

            mockParkingLotRepository.Verify(mock => mock.Create(It.IsAny<ParkingLot>()), Times.Once());
        }

        [Fact]
        public void GetAll_ShouldReturnAllParkingLotRecords()
        {
            var mockParkingLotRepository = new Mock<IParkingLotRepository>();
            List<ParkingLot> expectedList = new List<ParkingLot>()
            {
                new ParkingLot()
                {
                    Id = Guid.NewGuid(),
                    Name = "name 111",
                    Address = "address 111",
                    Description = "description 111",
                    Sessions = new List<Session>()
                    {
                        new Session()
                        {
                            
                        }
                    }
                },
                new ParkingLot()
                {
                    Id = Guid.NewGuid(),
                    Name = "name 222",
                    Address = "address 222",
                    Description = "description 222",
                    Sessions = new List<Session>()
                }
            };
            mockParkingLotRepository.Setup(repo => repo.GetAll()).Returns(expectedList);

            var service = new ParkingLotService(mockParkingLotRepository.Object);
            var actualList = (service as IParkingLotService).GetAll();

            Assert.Equal(expectedList, actualList);

            Assert.Equal(expectedList[0].Id, actualList[0].Id);
            Assert.Equal(expectedList[0].Name, actualList[0].Name);
            Assert.Equal(expectedList[0].Address, actualList[0].Address);
            Assert.Equal(expectedList[0].Description, actualList[0].Description);
            Assert.Equal(expectedList[0].Sessions, actualList[0].Sessions);
        }
    }
}
