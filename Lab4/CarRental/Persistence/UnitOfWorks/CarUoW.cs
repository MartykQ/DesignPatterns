﻿using CarRental.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Persistence.UnitOfWorks
{
    class CarUoW : ICarUoW
    {

        private readonly CarRentalContext _context;

        public ICarRepository CarRepository { get; }

        public CarUoW(CarRentalContext context)
        {
            this._context = context;
            this.CarRepository = new CarRepository(this._context);
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
