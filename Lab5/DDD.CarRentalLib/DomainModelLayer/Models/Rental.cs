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

        public Rental(
            Guid id,
            IDomainEventPublisher domainEventPublisher,
            DateTime started,
            Guid carId,
            Guid driverId
            ) : base(id, domainEventPublisher)
        {
            this.Started = started;
            this.CarId = carId;
            this.DriverId = driverId;
            Money startTotal = new Money(0);
            this.Total = startTotal;

        }

        public DateTime Started { get; protected set; }
        public DateTime Finished { get; protected set; }
        public Guid CarId { get; protected set; }
        public Guid DriverId { get; protected set; }
        public Money Total { get; protected set; }


        public double FinishRental(DateTime stopDate)
        {
            this.Finished = stopDate;
            double totalTimeElappsed = (this.Finished - this.Started).TotalMinutes;

            double totalValue = totalTimeElappsed * 5;
            this.Total = new Money((decimal)totalValue, "zl");

            return totalTimeElappsed;
        }
    }
}
