using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkEco.CoreAPI.Controllers.Models;
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

        [HttpPost]
        public ActionResult CreateNewParkingLot([FromBody]CreateNewParkingLotCommand command)
        {
            try
            {
                parkingLotService.Create(command.Name, command.Address, command.Description);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateParkingLot(Guid id, [FromBody]CreateNewParkingLotCommand updateCommand)
        {
            try
            {
                parkingLotService.Update(id, 
                    updateCommand.Name, updateCommand.Address, updateCommand.Description);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteParkingLot(Guid id)
        {
            try
            {
                parkingLotService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}