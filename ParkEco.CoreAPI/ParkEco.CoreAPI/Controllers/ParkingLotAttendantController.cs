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
    public class ParkingLotAttendantController : ControllerBase
    {
        private readonly IParkingLotAttendantService parkingLotAttendantService;
        public ParkingLotAttendantController(IParkingLotAttendantService parkingLotAttendantService)
        {
            this.parkingLotAttendantService = parkingLotAttendantService;
        }

        [HttpPost("log-in")]
        public ActionResult LogIn(
            [FromBody]LoginCommand command
            )
        {
            bool verifyResult = parkingLotAttendantService.IsPasswordCorrect(command.Username, command.Password);
            if (verifyResult == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("log-out")]
        public ActionResult LogOut()
        {
            return Ok();
        }

        [HttpPost("register")]
        public ActionResult Register(
            [FromBody]RegisterCommand command)
        {
            try
            {
                parkingLotAttendantService.RegisterNewAttendant(
                    command.Name,
                    command.Username,
                    command.Email,
                    command.PhoneNumber);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet()]
        public ActionResult<List<ParkingLotAttendant>> GetAllAttendants(
            [FromQuery]Guid? parkingLotId = null,
            [FromQuery]string username = null
            )
        {
            if (username != null)
            {
                var queryResult = parkingLotAttendantService.Get(username);
                var returnResult = new List<ParkingLotAttendant>
                {
                    queryResult
                };
                return returnResult;
            }

            if (parkingLotId.HasValue)
            {
                return StatusCode(StatusCodes.Status501NotImplemented);
            }
            else
            {
                return parkingLotAttendantService.GetAll();
            }
        }

        [HttpDelete("{username}")]
        public ActionResult DeleteAttendant(string username)
        {
            try
            {
                parkingLotAttendantService.DeleteAttendant(username);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}