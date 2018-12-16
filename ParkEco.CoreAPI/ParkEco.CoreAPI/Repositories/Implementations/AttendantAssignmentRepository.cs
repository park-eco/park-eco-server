using ParkEco.CoreAPI.Data;
using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Implementations
{
    public class AttendantAssignmentRepository : BaseRepository, IAttendantAssignmentRepository
    {
        public AttendantAssignmentRepository(ParkingEcoServerContext dbContext) : base(dbContext)
        {
        }

        void IAttendantAssignmentRepository.Create(AttendantAssignment attendantAssignment)
        {
            dbContext.AttendantAssignments.Add(attendantAssignment);
            dbContext.SaveChanges();
        }

        void IAttendantAssignmentRepository.Delete(AttendantAssignment attendantAssignment)
        {
            dbContext.AttendantAssignments.Remove(attendantAssignment);
            dbContext.SaveChanges();
        }

        List<AttendantAssignment> IAttendantAssignmentRepository.GetByParkingLotId(Guid parkingLotId)
        {
            var assignments = dbContext
                .AttendantAssignments
                .Where(assignment => assignment.ParkingLotId == parkingLotId)
                .ToList();

            return assignments;
        }
    }
}
