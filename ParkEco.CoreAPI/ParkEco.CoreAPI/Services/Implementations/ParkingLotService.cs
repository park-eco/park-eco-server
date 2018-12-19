using ParkEco.CoreAPI.Controllers.Models;
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

        void IParkingLotService.Create(string name, string address, string description)
        {
            parkingLotRepository.Create(new Data.Models.ParkingLot()
            {
                Name = name,
                Address = address,
                Description = description
            });
        }

        void IParkingLotService.Delete(Guid id)
        {
            parkingLotRepository.Delete(id);
        }

        ParkingLot IParkingLotService.Get(Guid id)
        {
            var parkingLot = parkingLotRepository.Get(id);
            return parkingLot;
        }

        List<ParkingLot> IParkingLotService.GetAll()
        {
            return parkingLotRepository.GetAll();
        }

        List<StatusQueryModel> IParkingLotService.QueryStatus()
        {
            var parkingLots = parkingLotRepository.GetAll();
            List<StatusQueryModel> result = new List<StatusQueryModel>();
            foreach (var parkingLot in parkingLots)
            {
                var fullPercentage = (parkingLot.MaximumCapacity != 0) ?
                    (parkingLot.CurrentCount / parkingLot.MaximumCapacity) * 100
                    : 0;
                result.Add(new StatusQueryModel()
                {
                    ParkingLotName = parkingLot.Name,
                    Longitude = parkingLot.Longitude,
                    Latitude = parkingLot.Latitude,
                    FullPercentage = fullPercentage
                });
            }
            return result;
        }

        void IParkingLotService.Update(Guid id, string name, string address, string description, double longitude, double latitude)
        {
            parkingLotRepository.Update(new ParkingLot()
            {
                Id = id,
                Name = name,
                Address = address,
                Description = description,
                Longitude = longitude,
                Latitude = latitude
            });
        }
    }
}
