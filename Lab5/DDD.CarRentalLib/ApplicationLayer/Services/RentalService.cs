using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.CarRentalLib.ApplicationLayer.Interfaces;
using DDD.CarRentalLib.ApplicationLayer.Mappers;
using DDD.CarRentalLib.DomainModelLayer.Interfaces;

namespace DDD.CarRentalLib.ApplicationLayer.Services
{
    public class RentalService : IRentalService
    {
        private ICarRentalUoW _uoW;
        private RentalMapper _rentalMapper;
        private IDomainEventPublisher _domainEventPublisher;

        public RentalService(ICarRentalUoW uoW, RentalMapper rentalMapper, IDomainEventPublisher domainEventPublisher)
        {
            _uoW = uoW;
            _rentalMapper = rentalMapper;
            _domainEventPublisher = domainEventPublisher;
        }
    }
}
