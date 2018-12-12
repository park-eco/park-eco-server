using ParkEco.CoreAPI.Data;
using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Implementations
{
    public class ParkingLotAttendantRepository : BaseRepository, IParkingLotAttendantRepository
    {
        public ParkingLotAttendantRepository(ParkingEcoServerContext dbContext) : base(dbContext)
        {
        }

        void IParkingLotAttendantRepository.Create(ParkingLotAttendant parkingLotAttendent)
        {
            dbContext.ParkingLotAttendants.Add(parkingLotAttendent);
            dbContext.SaveChanges();
        }

        void IParkingLotAttendantRepository.Delete(string username)
        {
            var userToBeDeleted = (this as IParkingLotAttendantRepository).Get(username);
            dbContext.ParkingLotAttendants.Remove(userToBeDeleted);
            dbContext.SaveChanges();
        }

        ParkingLotAttendant IParkingLotAttendantRepository.Get(string username)
        {
            try
            {
                var result = (from records
                      in dbContext.ParkingLotAttendants
                              where records.Username == username
                              select records).Single();
                return result;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException("Could not find any account with given username.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("Something went wrong with your account. Please contact the administrator.", ex);
            }

        }

        bool IParkingLotAttendantRepository.IsPasswordCorrect(string username, string toBeVerifiedPassword)
        {
            var user = (this as IParkingLotAttendantRepository).Get(username);
            if (toBeVerifiedPassword == user.Password)
            {
                // Given password is correct
                return true;
            }
            else
            {
                return false;
            }
        }

        void IParkingLotAttendantRepository.Update(ParkingLotAttendant parkingLotAttendant)
        {
            dbContext.ParkingLotAttendants.Update(parkingLotAttendant);
            dbContext.SaveChanges();
        }
    }
}
