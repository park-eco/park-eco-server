using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Interfaces
{
    public interface IParkingLotAttendantRepository
    {
        void Create(ParkingLotAttendant parkingLotAttendent);
        void Update(ParkingLotAttendant parkingLotAttendant);
        ParkingLotAttendant Get(string username);
        void Delete(string username);

        bool IsPasswordCorrect(string username, string toBeVerifiedPassword);

    }
}
