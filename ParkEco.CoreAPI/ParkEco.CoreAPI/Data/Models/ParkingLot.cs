using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Data.Models
{
    public class ParkingLot
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public int MaximumCapacity { get; set; }
        public int CurrentCount { get; set; }

        public ICollection<Session> Sessions { get; set; }
        
        public ICollection<AttendantAssignment> AttendantAssignments { get; set; }
    }
}
