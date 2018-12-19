using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Controllers.Models
{
    public class VerifyTicketCommand
    {
        public string Plate { get; set; }
        public Guid SecretKey { get; set; }
    }
}
