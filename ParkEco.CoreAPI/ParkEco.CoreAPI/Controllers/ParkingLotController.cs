﻿using System;
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
    public class ParkingLotsController : ControllerBase
    {
        private readonly IParkingLotService parkingLotService;
        public ParkingLotsController(IParkingLotService parkingLotService)
        {
            this.parkingLotService = parkingLotService;
        }

        [HttpGet]
        public ActionResult<List<ParkingLot>> GetAll()
        {
            return parkingLotService.GetAll();
        }

        [HttpGet("status")]
        public ActionResult<List<StatusQueryModel>> QueryStatus()
        {
            return parkingLotService.QueryStatus();
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
                    updateCommand.Name, updateCommand.Address, updateCommand.Description,
                    updateCommand.Longitude, updateCommand.Latitude);
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

        [HttpGet("report-daily")]
        public ActionResult<ReportQueryModel> GetReports(
            [FromQuery]DateTime from,
            [FromQuery]DateTime to,
            [FromQuery]Guid? parkingLotId = null
            )
        {
            if (parkingLotId.HasValue)
            {
                return parkingLotService.GetDailyReport(parkingLotId.Value,
                    from, to);
            }
            else
            {
                return parkingLotService.GetReports();
            }
        }

    }
}