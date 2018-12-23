using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Controllers.Models
{
    public class ReportQueryModel
    {
        public List<Guid> ParkingLotId { get; set; }
        public List<string> ParkingLotName { get; set; }
        public List<string> Label { get; set; }

        public List<ReportItem> ReportItems { get; set; }
    }
}
