using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.ApplicationLayer.Interfaces;
using DDD.CarRentalLib.ApplicationLayer.Mappers;
using DDD.CarRentalLib.DomainModelLayer.Factories;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;

namespace DDD.CarRentalLib.ApplicationLayer.Services
{
    public class RentalService : IRentalService
    {
        private ICarRentalUoW _uoW;
        private RentalMapper _rentalMapper;
        private IDomainEventPublisher _domainEventPublisher;
        private RentalFactory _rentalFactory;
        private FreeMinutesPolicyFactory _policyFactory;

        public RentalService(ICarRentalUoW uoW, FreeMinutesPolicyFactory policyFactory, RentalFactory rentalFactory, RentalMapper rentalMapper, IDomainEventPublisher domainEventPublisher)
        {
            _uoW = uoW;
            _rentalMapper = rentalMapper;
            _domainEventPublisher = domainEventPublisher;
            _rentalFactory = rentalFactory;
            _policyFactory = policyFactory; 
        }

        public void StartRental(Guid rentalId, Guid carId, Guid driverId, DateTime startTime)
        {
            Car car = this._uoW.CarRepository.Get(carId) ??
                throw new Exception("No car with this ID");

            Driver driver = this._uoW.DriverRepository.Get(driverId) ??
                throw new Exception("No driver with this ID!");

            Rental rental = this._rentalFactory.Create(rentalId, car, driver, startTime);

            IFreeMinutesPolicy policy = this._policyFactory.Create(driver);
            driver.RegisterPolicy(policy);

            car.DriveAway();

            this._uoW.RentalRepository.Insert(rental);
            this._uoW.Commit();
        }

        public List<RentalDTO> GetAllRentals()
        {
            IList<Rental> rentals = this._uoW.RentalRepository.GetAll();

            List<RentalDTO> dtoResult = this._rentalMapper.Map(rentals);

            return dtoResult;
        }


    }
}
