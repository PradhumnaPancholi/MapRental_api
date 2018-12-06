using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapRental_api.Models
{
    public class MapRentalModel : DbContext
    {
        public MapRentalModel(DbContextOptions<MapRentalModel>options) : base(options)
        {

        }
        //Rentals reference for CRUD functionality//
        public DbSet<Rental> Rentals { get; set; }

    }
}
