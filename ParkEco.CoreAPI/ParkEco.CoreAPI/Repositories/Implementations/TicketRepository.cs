using ParkEco.CoreAPI.Data;
using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Implementations
{
    public class TicketRepository : BaseRepository, ITicketRepository
    {
        public TicketRepository(ParkingEcoServerContext dbContext) : base(dbContext)
        {
        }

        Guid ITicketRepository.Create(string plate, Guid parkingLotAttendantId)
        {
            var newTicket = new Ticket()
            {
                Plate = plate,
                //SessionId = sessionId,
                IsValid = true,
                IsReturned = false,
                SecretKey = Guid.NewGuid(),
                ParkingLotAttendantId = parkingLotAttendantId,
                DateOfCreated = DateTime.UtcNow,
            };
            dbContext.Tickets.Add(newTicket);
            dbContext.SaveChanges();
            return newTicket.Id;
        }

        Ticket ITicketRepository.Get(Guid id)
        {
            return dbContext.Tickets.Where(ticket => ticket.Id == id).SingleOrDefault();
        }

        List<Ticket> ITicketRepository.GetAll()
        {
            return dbContext.Tickets.ToList();
        }

        void ITicketRepository.Update(Ticket ticket)
        {
            dbContext.Tickets.Update(ticket);
            dbContext.SaveChanges();
        }

        bool ITicketRepository.Verify(string plate, Guid secretKey)
        {
            var activeTicket = dbContext.Tickets.Where(ticket => ticket.Plate == plate && ticket.IsReturned == false
                && ticket.IsValid == true).SingleOrDefault();

            if (activeTicket == null)
            {
                throw new ArgumentException("No active ticket associates with this plate number is found.");
            }

            if (activeTicket.SecretKey == secretKey)
            {
                activeTicket.IsReturned = true;
                (this as ITicketRepository).Update(activeTicket);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
