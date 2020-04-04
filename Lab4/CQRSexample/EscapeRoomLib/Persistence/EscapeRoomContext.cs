using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Read;
using EscapeRoom_CQRS.Models.Write;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Persistence
{
    public class EscapeRoomContext : DbContext
    {
        // 1-n
        public DbSet<Player> Players { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public DbSet<ReservationView> ReservationViews { get; set; }
        public DbSet<VisitView> VisitViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EscapeRoom_CQRS;Trusted_Connection=True;");
        }
    }

    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
