using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Controllers.Models
{
    public class CreateReportCommand
    {
        public List<Guid> ParkingLotIds { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public bool IsDailyReport { get; set; } = false;
        public bool IsMonthlyReport { get; set; } = false;
        public bool IsYearlyReport { get; set; } = false;


    }
}
