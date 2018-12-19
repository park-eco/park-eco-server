using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Controllers.Models
{
    public class CreateTicketCommand
    {
        public string Plate { get; set; }
        public Guid ParkingLotAttendantId { get; set; }
    }
}
