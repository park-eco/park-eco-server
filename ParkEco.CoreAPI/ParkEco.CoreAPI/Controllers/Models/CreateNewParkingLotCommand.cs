﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Controllers.Models
{
    public class CreateNewParkingLotCommand
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
