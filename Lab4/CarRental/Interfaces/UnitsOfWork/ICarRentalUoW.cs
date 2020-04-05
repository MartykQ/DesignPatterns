using CarRental.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence.UnitOfWorks
{
    public interface ICarRentalUoW : IDisposable
    {
        IDriverRepository DriverRepository { get; }
        IRentalRepository RentalRepository { get;  }
        ICarRepository CarRepository { get;  }

        IRentalViewRepository RentalViewRepository { get; }

        void Commit();
        void RejectChanges();

    }
}
