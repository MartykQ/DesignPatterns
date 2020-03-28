using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkTrial
{
    class ReservationUnitOfWork : IReservationUnitOfWork
    {
        private readonly CarRentalContext _context;

        public IReservationRepository ReservationRepository { get; }

        public ReservationUnitOfWork(CarRentalContext cont)
        {
            this._context = cont;
            this.ReservationRepository = new ReservationRepository(this._context);
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
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
