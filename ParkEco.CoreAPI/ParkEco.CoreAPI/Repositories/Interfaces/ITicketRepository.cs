using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        void Create(string plate, Guid sessionId);
    }
}
