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

        void ITicketRepository.Create(string plate, Guid sessionId)
        {
            dbContext.Tickets.Add(new Ticket()
            {
                Plate = plate,
                SessionId = sessionId,
                IsValid = true,
                IsReturned = false
            });
        }
    }
}
