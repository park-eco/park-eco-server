using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEco.CoreAPI.Data.Models;
using ParkEco.CoreAPI.Services.Interfaces;

namespace ParkEco.CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        private readonly IParkingLotService parkingLotService;
        public ParkingLotController(IParkingLotService parkingLotService)
        {
            this.parkingLotService = parkingLotService;
        }

        [HttpGet]
        public ActionResult<List<ParkingLot>> GetAll()
        {
            return parkingLotService.GetAll();
        }
    }
}