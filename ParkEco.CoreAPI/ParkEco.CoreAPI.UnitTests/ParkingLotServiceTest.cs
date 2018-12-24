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
            var stubTicketRepository = new Mock<ITicketRepository>();
            var stubAttendantAssignmentRepository = new Mock<IAttendantAssignmentRepository>();

            var service = new ParkingLotService(mockParkingLotRepository.Object, stubTicketRepository.Object, stubAttendantAssignmentRepository.Object);
            (service as IParkingLotService).Create("expected name", "expected address", "expected description");

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
                    },
                    Longitude = 1.0f,
                    Latitude = 1.0f,
                    AttendantAssignments = new List<AttendantAssignment>()
                },
                new ParkingLot()
                {
                    Id = Guid.NewGuid(),
                    Name = "name 222",
                    Address = "address 222",
                    Description = "description 222",
                    Sessions = new List<Session>(),
                    Longitude = 1.0f,
                    Latitude = 1.0f,
                    AttendantAssignments = new List<AttendantAssignment>()
                }
            };
            mockParkingLotRepository.Setup(repo => repo.GetAll()).Returns(expectedList);
            var stubTicketRepository = new Mock<ITicketRepository>();
            var stubAttendantAssignmentRepository = new Mock<IAttendantAssignmentRepository>();

            var service = new ParkingLotService(mockParkingLotRepository.Object, stubTicketRepository.Object, stubAttendantAssignmentRepository.Object);
            var actualList = (service as IParkingLotService).GetAll();

            Assert.Equal(expectedList, actualList);

            Assert.Equal(expectedList[0].Id, actualList[0].Id);
            Assert.Equal(expectedList[0].Name, actualList[0].Name);
            Assert.Equal(expectedList[0].Address, actualList[0].Address);
            Assert.Equal(expectedList[0].Description, actualList[0].Description);
            Assert.Equal(expectedList[0].Sessions, actualList[0].Sessions);
        }

        [Fact]
        public void Delete_ShouldCallDeleteMethodInRepository()
        {
            var mockParkingLotRepository = new Mock<IParkingLotRepository>();
            mockParkingLotRepository.Setup(repo => repo.Delete(It.IsAny<Guid>())).Verifiable();
            var stubTicketRepository = new Mock<ITicketRepository>();
            var stubAttendantAssignmentRepository = new Mock<IAttendantAssignmentRepository>();

            var service = new ParkingLotService(mockParkingLotRepository.Object, stubTicketRepository.Object, stubAttendantAssignmentRepository.Object);
            (service as IParkingLotService).Delete(Guid.NewGuid());

            mockParkingLotRepository.Verify(mock => mock.Delete(It.IsAny<Guid>()), Times.Once());
        }

        [Fact]
        public void Delete_ShouldPassGuidToRepositoryMethod()
        {
            var mockParkingLotRepository = new Mock<IParkingLotRepository>();
            var expectedId = Guid.NewGuid();
            mockParkingLotRepository.Setup(repo => repo.Delete(expectedId)).Verifiable();
            var stubTicketRepository = new Mock<ITicketRepository>();
            var stubAttendantAssignmentRepository = new Mock<IAttendantAssignmentRepository>();

            var service = new ParkingLotService(mockParkingLotRepository.Object, stubTicketRepository.Object, stubAttendantAssignmentRepository.Object);
            (service as IParkingLotService).Delete(expectedId);

            mockParkingLotRepository.Verify(mock => mock.Delete(expectedId), Times.Once());
        }
    }
}
