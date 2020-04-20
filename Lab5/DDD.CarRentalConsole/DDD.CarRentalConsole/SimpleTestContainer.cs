using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Services;
using DDD.CarRentalLib.ApplicationLayer.Interfaces;
using DDD.CarRentalLib.ApplicationLayer.Mappers;
using DDD.CarRentalLib.ApplicationLayer.Services;
using DDD.CarRentalLib.DomainModelLayer.Factories;
using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.CarRentalLib.DomainModelLayer.Services;
using DDD.CarRentalLib.InfrastructureLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalConsole
{
    public class SimpleTestContainer
    {
        public IDriverService DriverService { get; }
        public ICarService CarService { get; }
        public IRentalService RentalService { get; }
        public FinishRentalService FinishRentalService { get;  }


        public SimpleTestContainer()
        {
            var domainEventPublisher = new SimpleEventPublisher();

            var uoW = new MemoryCarRentalUoW(
                    new MemoryRepository<Driver>(),
                    new MemoryRepository<Car>(),
                    new MemoryRepository<Rental>()
                );

            var freeMinutesPolicyFactory = new FreeMinutesPolicyFactory();
            var rentalFactory = new RentalFactory(domainEventPublisher);

            var carMapper = new CarMapper();
            var driverMapper = new DriverMapper();
            var rentalMapper = new RentalMapper();


            this.DriverService = new DriverService(uoW, driverMapper, domainEventPublisher);
            this.CarService = new CarService(uoW, carMapper, domainEventPublisher);
            this.RentalService = new RentalService(uoW, freeMinutesPolicyFactory, rentalFactory, rentalMapper, domainEventPublisher);
            this.FinishRentalService = new FinishRentalService(uoW, domainEventPublisher);
        }

    }
}
