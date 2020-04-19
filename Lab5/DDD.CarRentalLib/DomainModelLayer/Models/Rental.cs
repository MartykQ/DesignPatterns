using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Rental : AggregateRoot
    {
        public Rental(
            Guid id,
            IDomainEventPublisher domainEventPublisher,
            DateTime started,
            DateTime finished,
            Guid carId,
            Guid driverId,
            Money total
            ) : base(id, domainEventPublisher)
        {
            this.Started = started;
            this.Finished = finished;
            this.CarId = carId;
            this.DriverId = driverId;
            this.Total = total;
        }

        public DateTime Started { get; protected set; }
        public DateTime Finished { get; protected set; }
        public Guid CarId { get; protected set; }
        public Guid DriverId { get; protected set; }
        public Money Total { get; protected set; }


    }
}
