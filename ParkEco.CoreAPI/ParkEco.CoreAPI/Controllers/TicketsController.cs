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
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService ticketService;
        public TicketsController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpPost]
        public ActionResult CreateTicket([FromBody]CreateTicketCommand command)
        {
            try
            {
                var secretKey = ticketService.Create(command.Plate, command.ParkingLotAttendantId);
                return Ok(new { SecretKey = secretKey });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPatch("verify")]
        public ActionResult VerifyTicket([FromBody]VerifyTicketCommand command)
        {
            var verifyResult = ticketService.Verify(command.Plate, command.SecretKey);
            if (verifyResult == true)
            {
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet]
        public ActionResult<List<Ticket>> GetAll()
        {
            return ticketService.GetAll();
        }
    }
}