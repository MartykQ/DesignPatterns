using CarRental.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence.UnitOfWorks
{
    interface IRentalUoW : IDisposable
    {
        IRentalRepository RentalRepository { get; }
        void Commit();
        void RejectChanges();
    }
}
