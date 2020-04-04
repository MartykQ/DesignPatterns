using CarRental.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Persistence.UnitOfWorks
{
    interface ICarUoW : IDisposable
    {
        ICarRepository CarRepository { get; }
        void Commit();
        void RejectChanges();

    }
}
