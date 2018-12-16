using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Controllers.Models
{
    public class LoginCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
