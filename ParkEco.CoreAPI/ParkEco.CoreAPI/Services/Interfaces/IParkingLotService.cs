using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Services.Interfaces
{
    public interface IParkingLotService
    {
        void Create(string name, string address);

        void Get(Guid id);
        List<ParkingLot> GetAll();
    }
}
