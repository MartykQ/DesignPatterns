using DDD.Base.DomainModelLayer.Events;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using DDD.CarRentalLib.ApplicationLayer.Interfaces;
using DDD.CarRentalLib.ApplicationLayer.Mappers;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using DDD.CarRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.Services
{
    public class CarService : ICarService
    {
        private ICarRentalUoW _uoW;
        private CarMapper _carMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public CarService(ICarRentalUoW uoW, CarMapper carMapper, IDomainEventPublisher domainEventPublisher)
        {
            _uoW = uoW;
            _carMapper = carMapper;
            _domainEventPublisher = domainEventPublisher;
        }

        public void CreateCar(CarDTO carDTO)
        {
            Expression<Func<Car, bool>> expressionPredicate = x => x.RegistrationNumber == carDTO.RegistrationNumber;
            Car car = this._uoW.CarRepository.Find(expressionPredicate).FirstOrDefault();
            if (car != null)
                throw new Exception($"Car with this registration: '{carDTO.RegistrationNumber}' already exists!.");


            Position currentPosition = new Position(carDTO.CurrentPosition.XPosition, carDTO.CurrentPosition.YPosition, (DistanceUnit)carDTO.CurrentPosition.Unit);
            Distance totalDistance = new Distance(carDTO.TotalDistance.Value, (DistanceUnit)carDTO.TotalDistance.Unit);
            Distance currentDistance = new Distance(carDTO.CurrentDistance.Value, (DistanceUnit)carDTO.CurrentDistance.Unit);


            car = new Car(carDTO.Id,
                this._domainEventPublisher,
                currentPosition,
                carDTO.RegistrationNumber,
                (CarStatus)carDTO.Status,
                totalDistance,
                currentDistance);


            this._uoW.CarRepository.Insert(car);
            this._uoW.Commit();


        }

    }
}
