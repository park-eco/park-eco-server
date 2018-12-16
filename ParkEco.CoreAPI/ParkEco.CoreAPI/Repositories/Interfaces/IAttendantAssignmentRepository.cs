using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Interfaces
{
    public interface IAttendantAssignmentRepository
    {
        List<AttendantAssignment> GetByParkingLotId(Guid parkingLotId);

        void Create(AttendantAssignment attendantAssignment);
        void Delete(AttendantAssignment attendantAssignment);
    }
}
