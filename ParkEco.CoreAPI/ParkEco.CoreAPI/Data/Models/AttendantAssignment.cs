using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Data.Models
{
    public class AttendantAssignment
    {
        public Guid Id { get; set; }

        public Guid ParkingLotId { get; set; }
        public ParkingLot ParkingLot { get; set; }

        public Guid ParkingLotAttendantId { get; set; }
        public ParkingLotAttendant ParkingLotAttendant { get; set; }
    }
}
