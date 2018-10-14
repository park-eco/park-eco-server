using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using ParkEco.CoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Services.Implementations
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository parkingLotRepository;
        public ParkingLotService(IParkingLotRepository parkingLotRepository)
        {
            this.parkingLotRepository = parkingLotRepository;
        }

        void IParkingLotService.Create(string name, string address)
        {
            parkingLotRepository.Create(new Data.Models.ParkingLot()
            {
                Name = name,
                Address = address
            });
        }

        void IParkingLotService.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        List<ParkingLot> IParkingLotService.GetAll()
        {
            return parkingLotRepository.GetAll();
        }
    }
}
