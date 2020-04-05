using CarRental.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence.UnitOfWorks
{
    interface IRentalViewUoW : IDisposable
    {
        IRentalViewRepository RentalViewRepository { get; }
        void Commit();
        void RejectChanges();

    }
}
