using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Interfaces
{
    public interface IParkingLotRepository
    {
        ParkingLot Get(Guid id);
        List<ParkingLot> GetAll();

        void Create(ParkingLot parkingLot);

        void Update(ParkingLot parkingLot);

        void Delete(Guid id);
    }
}
