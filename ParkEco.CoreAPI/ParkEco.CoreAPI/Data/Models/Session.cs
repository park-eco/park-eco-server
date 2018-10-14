using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Data.Models
{
    public class Session
    {
        public Guid Id { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Guid ParkingLotId { get; set; }
        public ParkingLot ParkingLot { get; set; }
    }
}
