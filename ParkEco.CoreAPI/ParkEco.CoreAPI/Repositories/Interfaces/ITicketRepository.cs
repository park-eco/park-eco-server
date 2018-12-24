using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Guid Create(string plate, Guid parkingLotAttendantId);

        void Update(Ticket ticket);

        Ticket Get(Guid id);
        List<Ticket> GetAll();
        List<Ticket> GetByParkingAttendant(Guid parkingLotAttendantId);

        bool Verify(string plate, Guid secretKey);
    }
}
