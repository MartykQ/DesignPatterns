﻿using CarRental.Models.Read;
using CarRental.Models.Write;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence
{
    class CarRentalContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Reservations { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RentalView> RentalViews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRental;Trusted_Connection=True;");
        }


    }
}
