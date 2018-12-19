using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Controllers.Models
{
    public class StatusQueryModel
    {
        public string ParkingLotName { get; set; }

        public string CurrentEmployee { get; set; }

        /// <summary>
        /// This parking lot is x percentage full.
        /// </summary>
        public int FullPercentage { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
