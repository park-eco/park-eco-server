using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Services.Interfaces
{
    public interface ITicketService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plate"></param>
        /// <param name="parkingLotAttendantId"></param>
        /// <returns>Return secret key of this tickey.</returns>
        Guid Create(string plate, Guid parkingLotAttendantId);

        /// <summary>
        /// User returns this ticket and verify with his/her vehicle.
        /// </summary>
        bool Verify(string plate, Guid secretKey);

        List<Ticket> GetAll();
    }
}
