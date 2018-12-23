using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Services.Interfaces
{

    public interface IParkingLotService
    {
        void Create(string name, string address, string description);
        void Update(Guid id, string name, string address, string description, double longitude, double latitude);
        void Delete(Guid id);

        ParkingLot Get(Guid id);
        List<ParkingLot> GetAll();

        List<Controllers.Models.StatusQueryModel> QueryStatus();

        /// <summary>
        /// Get reports of all available parking lots.
        /// </summary>
        /// <returns></returns>
        List<Controllers.Models.ReportQueryModel> GetReports();

        /// <summary>
        /// Get report for a specified parking lot.
        /// </summary>
        /// <param name="parkingLotId"></param>
        /// <returns></returns>
        Controllers.Models.ReportQueryModel GetReport(Guid parkingLotId);
    } 
}
