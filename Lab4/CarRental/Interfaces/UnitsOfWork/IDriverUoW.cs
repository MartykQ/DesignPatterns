using CarRental.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence.UnitOfWorks
{
    interface IDriverUoW : IDisposable
    {
        IDriverRepository DriverRepository { get; }
        void Commit();
        void RejectChanges();
    }
}
