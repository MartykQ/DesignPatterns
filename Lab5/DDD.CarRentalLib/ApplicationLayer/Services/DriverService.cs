using DDD.Base.DomainModelLayer.Events;
using DDD.CarRentalLib.ApplicationLayer.Interfaces;
using DDD.CarRentalLib.ApplicationLayer.Mappers;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.Services
{
    public class DriverService : IDriverService
    {
        private ICarRentalUoW _uoW;
        private DriverMapper _driverMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public DriverService(ICarRentalUoW uoW, DriverMapper driverMapper, IDomainEventPublisher domainEventPublisher)
        {
            _uoW = uoW;
            _driverMapper = driverMapper;
            _domainEventPublisher = domainEventPublisher;
        }
    }
}
