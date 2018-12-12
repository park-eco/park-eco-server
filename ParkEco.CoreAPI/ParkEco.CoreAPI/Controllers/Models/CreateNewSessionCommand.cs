using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Controllers.Models
{
    public class CreateNewSessionCommand
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Guid ParkingLotId { get; set; }
    }
}
