using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Services.Interfaces
{
    public interface IParkingLotAttendantService
    {
        ParkingLotAttendant RegisterNewAttendant(string name, string username, string email, string phoneNumber);

        bool IsPasswordCorrect(string username, string passwordToBeVerified);

        ParkingLotAttendant Get(string username);

        List<ParkingLotAttendant> GetAll();

        void UpdateInformation(string username, string name, string email, string phoneNumber, string password);

        void DeleteAttendant(string username);
    }
}
