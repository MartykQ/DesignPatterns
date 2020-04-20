using DDD.Base.DomainModelLayer.Events;
using DDD.Base.InfrastructureLayer.Services;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.InfrastructureLayer
{
    public class PositionService : IInfrastructureService
    {
        private IDomainEventPublisher _domainEventPublisher;
        private ICarRentalUoW _uoW;

        public PositionService(IDomainEventPublisher domainEventPublisher, ICarRentalUoW uoW)
        {
            _domainEventPublisher = domainEventPublisher;
            _uoW = uoW;
        }

        public Position GetCarPosition(Guid carId)
        {
            Car car = this._uoW.CarRepository.Get(carId) ??
                throw new Exception("This car does not exist!");

            Random rmd = new Random();
            double xPos = rmd.NextDouble() * 1000;
            double yPos = rmd.NextDouble() * 1000;
            return new Position(xPos, yPos, DistanceUnit.Kilometers);
        }

    }
}
