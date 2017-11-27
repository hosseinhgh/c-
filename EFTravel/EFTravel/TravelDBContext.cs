using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTravel
{
    class TravelDbContext : DbContext
    {
        public TravelDbContext() : base()
        {
        }

        public virtual DbSet<Trip> Trips { get; set; }
    }
}
