using ParkEco.CoreAPI.Data;
using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Implementations
{
    public class ParkingLotRepository : BaseRepository, IParkingLotRepository
    {
        public ParkingLotRepository(ParkingEcoServerContext dbContext)
            : base(dbContext)
        { }

        void IParkingLotRepository.Create(ParkingLot parkingLot)
        {
            dbContext.ParkingLots.Add(parkingLot);
            dbContext.SaveChanges();
        }

        void IParkingLotRepository.Delete(Guid id)
        {
            var idToDelete = (from records
                              in dbContext.ParkingLots
                              where records.Id == id
                              select records).Single();
            dbContext.ParkingLots.Remove(idToDelete);
            dbContext.SaveChanges();
        }

        ParkingLot IParkingLotRepository.Get(Guid id)
        {
            var result = (from records
                          in dbContext.ParkingLots
                          where records.Id == id
                          select records).Single();
            return result;
        }

        List<ParkingLot> IParkingLotRepository.GetAll()
        {
            var result = (from records 
                          in dbContext.ParkingLots
                          select records).ToList();
            return result;
        }

        void IParkingLotRepository.Update(ParkingLot parkingLot)
        {
            dbContext.ParkingLots.Update(parkingLot);
            dbContext.SaveChanges();
        }
    }
}
