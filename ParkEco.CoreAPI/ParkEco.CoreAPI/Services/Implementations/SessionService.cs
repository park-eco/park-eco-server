using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using ParkEco.CoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Services.Implementations
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository sessionRepository;
        public SessionService(ISessionRepository sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        void ISessionService.Create(DateTime from, DateTime to, Guid parkingLotId)
        {
            sessionRepository.Create(new Data.Models.Session()
            {
                From = from,
                To = to,
                ParkingLotId = parkingLotId
            });
        }

        void ISessionService.Delete(Guid id)
        {
            sessionRepository.Delete(id);
        }

        List<Session> ISessionService.GetAll()
        {
            return sessionRepository.GetAll();
        }

        List<Session> ISessionService.GetSessionsOfParkingLot(Guid parkingLotId)
        {
            return sessionRepository.GetSessionsOfParkingLot(parkingLotId);
        }
    }
}
