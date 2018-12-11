using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Data.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }

        [Required]
        public Guid SessionId { get; set; }
        public Session Session { get; set; }

        public string Plate { get; set; }

        /// <summary>
        /// When a ticket is used to take a car out, the ticket is now returned.
        /// </summary>
        public bool IsReturned { get; set; } = false;

        public bool IsValid { get; set; } = true;

        [ForeignKey("ParkingLotAttendant")]
        public Guid ParkingLotAttendantId { get; set; }
        public ParkingLotAttendant ParkingLotAttendant { get; set; }
    }
}
