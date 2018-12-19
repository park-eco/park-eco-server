using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using ParkEco.CoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        Guid ITicketService.Create(string plate, Guid parkingLotAttendantId)
        {
            var newlyCreatedTicketId = ticketRepository.Create(plate, parkingLotAttendantId);
            var newTicket = ticketRepository.Get(newlyCreatedTicketId);
            return newTicket.SecretKey;
        }

        List<Ticket> ITicketService.GetAll()
        {
            return ticketRepository.GetAll();
        }

        bool ITicketService.Verify(string plate, Guid secretKey)
        {
            return ticketRepository.Verify(plate, secretKey);
        }
    }
}
