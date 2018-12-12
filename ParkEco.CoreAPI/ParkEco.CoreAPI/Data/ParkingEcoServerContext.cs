using Microsoft.EntityFrameworkCore;
using ParkEco.CoreAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkEco.CoreAPI.Data
{
    public class ParkingEcoServerContext : DbContext
    {
        public ParkingEcoServerContext(DbContextOptions<ParkingEcoServerContext> options)
            : base(options)
        { }

        public DbSet<ParkingLot> ParkingLots { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<ParkingLotAttendant> ParkingLotAttendants { get; set; }
    }
}
