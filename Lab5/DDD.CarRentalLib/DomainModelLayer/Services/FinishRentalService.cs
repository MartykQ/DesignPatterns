using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Services;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.CarRentalLib.InfrastructureLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.DomainModelLayer.Services
{
    public class FinishRentalService : IDomainService
    {
        private ICarRentalUoW _uoW;
        private IDomainEventPublisher _domainEventPublisher;

        private PositionService _positionService;
        public FinishRentalService(ICarRentalUoW uoW, IDomainEventPublisher domainEventPublisher)
        {
            _uoW = uoW;
            _domainEventPublisher = domainEventPublisher;
            _positionService = new PositionService(domainEventPublisher, uoW);
        }

        public void FinishRental(Guid rentalId, Guid carId, Guid driverId, DateTime finishTime)
        {
            Rental rental = this._uoW.RentalRepository.Get(rentalId) ??
                throw new Exception("Rental does not exist!");

            Driver driver = this._uoW.DriverRepository.Get(driverId) ??
                throw new Exception("Driver does not exist!");

            Car car = this._uoW.CarRepository.Get(carId) ??
                throw new Exception("Car does not exists!");

            car.FreeUp();
            Position finalPosition = this._positionService.GetCarPosition(carId);
            car.UpdatePosition(finalPosition);

            double minutesEllapsed = rental.FinishRental(finishTime);

            // Im dluzej trwalo wypozczenie tym wiecej dodatkowych minut dostanie
            // kierowca (Rozwniez w zaleznosci od Policy)
            driver.UpdateFreeMinutes(minutesEllapsed);

            this._uoW.Commit();

        }
    }
}
