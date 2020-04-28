using DDD.Base.DomainModelLayer.Events;
using DDD.CarRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.DomainModelLayer.Factories
{
    public class RentalFactory
    {
        private IDomainEventPublisher _domainEventPublisher;

        public RentalFactory(IDomainEventPublisher domainEventPublisher)
        {
            _domainEventPublisher = domainEventPublisher;
        }

        public Rental Create(Guid rentalId, Car car, Driver driver, DateTime startDate, Guid employeeId)
        {
            CheckIfCarFree(car);
            return new Rental(rentalId, this._domainEventPublisher, startDate, car.Id, driver.Id, employeeId);
        }
        private void CheckIfCarFree(Car car)
        {
            if (car.Status != CarStatus.Free) throw new Exception("This car is not free");
        }
    }
}
