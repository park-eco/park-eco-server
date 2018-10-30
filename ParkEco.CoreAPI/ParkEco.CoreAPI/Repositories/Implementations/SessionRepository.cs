using ParkEco.CoreAPI.Data;
using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Implementations
{
    public class SessionRepository : BaseRepository, ISessionRepository
    {
        public SessionRepository(ParkingEcoServerContext dbContext) : base(dbContext)
        {
        }

        void ISessionRepository.Create(Session session)
        {
            dbContext.Sessions.Add(session);
        }

        void ISessionRepository.Delete(Guid id)
        {
            var sessionToDelete = dbContext.Sessions.Where(s => s.Id == id).SingleOrDefault();
            if (sessionToDelete != null)
            {
                dbContext.Sessions.Remove(sessionToDelete);
                return;
            }
            else
            {
                throw new ArgumentException($"Required {id} does not exist");
            }
        }

        Session ISessionRepository.Get(Guid id)
        {
            var result = (from records
                          in dbContext.Sessions
                          where records.Id == id
                          select records).SingleOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"Required {id} does not exist");
            }
        }

        List<Session> ISessionRepository.Get(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        List<Session> ISessionRepository.Get(DateTime date)
        {
            throw new NotImplementedException();
        }

        List<Session> ISessionRepository.GetAll()
        {
            return dbContext.Sessions.ToList();
        }

        void ISessionRepository.Update(Session session)
        {
            dbContext.Sessions.Update(session);
        }
    }
}
