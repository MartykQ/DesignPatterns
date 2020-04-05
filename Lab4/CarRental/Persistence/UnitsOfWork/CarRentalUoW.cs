using CarRental.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Persistence.UnitOfWorks
{
    public class CarRentalUoW : ICarRentalUoW
    {
        private readonly CarRentalContext _context;
        public IDriverRepository DriverRepository { get; }

        public IRentalRepository RentalRepository { get; }

        public ICarRepository CarRepository { get; }

        public IRentalViewRepository RentalViewRepository { get; }

        public CarRentalUoW(CarRentalContext context)
        {
            this._context = context;
            this.DriverRepository = new DriverRepository(this._context);
            this.RentalRepository = new RentalRepository(this._context);
            this.CarRepository = new CarRepository(this._context);
            this.RentalViewRepository = new RentalViewRepository(this._context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RejectChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries()
                        .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
