using ParkEco.CoreAPI.Controllers.Models;
using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using ParkEco.CoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Services.Implementations
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository parkingLotRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly IAttendantAssignmentRepository attendantAssignmentRepository;
        public ParkingLotService(
            IParkingLotRepository parkingLotRepository, 
            ITicketRepository ticketRepository,
            IAttendantAssignmentRepository attendantAssignmentRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
            this.ticketRepository = ticketRepository;
            this.attendantAssignmentRepository = attendantAssignmentRepository;
        }

        void IParkingLotService.Create(string name, string address, string description)
        {
            parkingLotRepository.Create(new Data.Models.ParkingLot()
            {
                Name = name,
                Address = address,
                Description = description
            });
        }

        void IParkingLotService.Delete(Guid id)
        {
            parkingLotRepository.Delete(id);
        }

        ParkingLot IParkingLotService.Get(Guid id)
        {
            var parkingLot = parkingLotRepository.Get(id);
            return parkingLot;
        }

        List<ParkingLot> IParkingLotService.GetAll()
        {
            return parkingLotRepository.GetAll();
        }

        ReportQueryModel IParkingLotService.GetDailyReport(Guid parkingLotId, DateTime from, DateTime to)
        {
            List<Ticket> tickets = new List<Ticket>();
            foreach(var assignment in attendantAssignmentRepository.GetByParkingLotId(parkingLotId))
            {
                // Prepare the raw tickets of each attendant.
                var ticket = ticketRepository.GetByParkingAttendant(assignment.ParkingLotAttendantId);
                ticket.RemoveAll(tic => tic.DateOfCreated >= from && tic.DateOfCreated <= to);

                // Add to the final collection.
                tickets.AddRange(ticket);
            }

            var targetParkingLot = parkingLotRepository.Get(parkingLotId);
            var labelList = new List<string>();
            for(var dt = from; dt <= to; dt = dt.AddDays(1))
            {
                labelList.Add(dt.ToShortDateString());
            }
            var reportItems = new List<int>();
            for (var dt = from; dt <= to; dt = dt.AddDays(1))
            {
                reportItems.Add(tickets.Where(tic => tic.DateOfCreated == dt).Count());
            }

            ReportQueryModel report = new ReportQueryModel()
            {
                ParkingLotId = new List<Guid>() { targetParkingLot.Id },
                ParkingLotName = new List<string>() { targetParkingLot.Name },
                Label = labelList,
                ReportItems = reportItems
            };
            return report;
        }

        ReportQueryModel IParkingLotService.GetReports()
        {
            throw new NotImplementedException();
        }

        List<StatusQueryModel> IParkingLotService.QueryStatus()
        {
            var parkingLots = parkingLotRepository.GetAll();
            List<StatusQueryModel> result = new List<StatusQueryModel>();
            foreach (var parkingLot in parkingLots)
            {
                var fullPercentage = (parkingLot.MaximumCapacity != 0) ?
                    (parkingLot.CurrentCount / parkingLot.MaximumCapacity) * 100
                    : 0;
                result.Add(new StatusQueryModel()
                {
                    ParkingLotName = parkingLot.Name,
                    Longitude = parkingLot.Longitude,
                    Latitude = parkingLot.Latitude,
                    FullPercentage = fullPercentage
                });
            }
            return result;
        }

        void IParkingLotService.Update(Guid id, string name, string address, string description, double longitude, double latitude)
        {
            parkingLotRepository.Update(new ParkingLot()
            {
                Id = id,
                Name = name,
                Address = address,
                Description = description,
                Longitude = longitude,
                Latitude = latitude
            });
        }
    }
}
