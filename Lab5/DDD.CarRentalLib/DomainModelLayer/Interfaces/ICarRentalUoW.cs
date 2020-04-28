using DDD.Base.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.DomainModelLayer.Interfaces
{
    public interface ICarRentalUoW : IUnitOfWork, IDisposable
    {
        IRepository<Driver> DriverRepository { get;  }
        IRepository<Car> CarRepository { get;  }
        IRepository<Rental> RentalRepository { get; }
        IRepository<Employee> EmployeeRepository { get; }
    }
}
