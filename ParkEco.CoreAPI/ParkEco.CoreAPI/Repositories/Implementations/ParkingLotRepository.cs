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
            throw new NotImplementedException();
        }

        void IParkingLotRepository.Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        ParkingLot IParkingLotRepository.Get(Guid id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
