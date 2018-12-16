using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using ParkEco.CoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Services.Implementations
{
    public class ParkingLotAttendantService : IParkingLotAttendantService
    {
        private readonly IParkingLotAttendantRepository parkingLotAttendantRepository;
        private readonly IAttendantAssignmentRepository attendantAssignmentRepository;
        public ParkingLotAttendantService(IParkingLotAttendantRepository parkingLotAttendantRepository)
        {
            this.parkingLotAttendantRepository = parkingLotAttendantRepository;
        }

        void IParkingLotAttendantService.DeleteAttendant(string username)
        {
            parkingLotAttendantRepository.Delete(username);
        }

        ParkingLotAttendant IParkingLotAttendantService.Get(string username)
        {
            return parkingLotAttendantRepository.Get(username);
        }

        List<ParkingLotAttendant> IParkingLotAttendantService.GetAll()
        {
            return parkingLotAttendantRepository.GetAll();
        }

        bool IParkingLotAttendantService.IsPasswordCorrect(string username, string passwordToBeVerified)
        {
            return parkingLotAttendantRepository.IsPasswordCorrect(username, passwordToBeVerified);
        }

        ParkingLotAttendant IParkingLotAttendantService.RegisterNewAttendant(string name, string username, string email, string phoneNumber)
        {
            parkingLotAttendantRepository.Create(new ParkingLotAttendant()
            {
                Name = name,
                Username = username,
                Password = "abc123", // Default for now
                Email = email,
                PhoneNumber = phoneNumber
            });
            return parkingLotAttendantRepository.Get(username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">Used to look for the user only. This won't be changed.</param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="password"></param>
        void IParkingLotAttendantService.UpdateInformation(string username, string name, string email, string phoneNumber, string password)
        {
            var userToBeModified = parkingLotAttendantRepository.Get(username);
            userToBeModified.Name = name;
            userToBeModified.Email = email;
            userToBeModified.PhoneNumber = phoneNumber;
            userToBeModified.Password = password;
            parkingLotAttendantRepository.Update(userToBeModified);
        }
    }
}
