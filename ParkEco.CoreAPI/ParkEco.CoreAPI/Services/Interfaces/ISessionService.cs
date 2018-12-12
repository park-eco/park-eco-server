using Microsoft.AspNetCore.Mvc;
using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Services.Interfaces
{
    public interface ISessionService
    {
        void Create(DateTime from, DateTime to, Guid parkingLotId);

        List<Session> GetSessionsOfParkingLot(Guid parkingLotId);
        List<Session> GetAll();

        void Delete(Guid id);
    }
}
