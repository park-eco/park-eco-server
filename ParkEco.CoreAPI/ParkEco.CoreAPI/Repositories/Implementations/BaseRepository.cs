using ParkEco.CoreAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Repositories.Implementations
{
    public class BaseRepository
    {
        public readonly ParkingEcoServerContext dbContext;

        public BaseRepository(ParkingEcoServerContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
