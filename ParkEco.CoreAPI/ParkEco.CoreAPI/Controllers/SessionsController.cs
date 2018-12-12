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
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService sessionService;
        public SessionsController(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        [HttpPost]
        public ActionResult CreateNewSession([FromBody]CreateNewSessionCommand command)
        {
            try
            {
                sessionService.Create(command.From, command.To, command.ParkingLotId);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult<List<Session>> GetSessions(
            [FromQuery]Guid? parkingLotId = null
            )
        {
            if (parkingLotId.HasValue)
            {
                return sessionService.GetSessionsOfParkingLot(parkingLotId.Value);
            }
            return sessionService.GetAll();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSession(Guid id)
        {
            try
            {
                sessionService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}