using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Session Get(Guid id);

        /// <summary>
        /// Get sessions which was run in between two time stamps.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        List<Session> Get(DateTime from, DateTime to);

        /// <summary>
        /// Get sessions which was run in an exact date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<Session> Get(DateTime date);

        List<Session> GetAll();

        List<Session> GetSessionsOfParkingLot(Guid parkingLotId);

        void Create(Session session);

        void Update(Session session);

        void Delete(Guid id);
    }
}
