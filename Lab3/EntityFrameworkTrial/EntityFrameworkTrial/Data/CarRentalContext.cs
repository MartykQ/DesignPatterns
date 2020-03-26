using EntityFrameworkTrial;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTrial
{
    public class CarRentalContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFTrail;Trusted_Connection=True;");
        }
    }
}
