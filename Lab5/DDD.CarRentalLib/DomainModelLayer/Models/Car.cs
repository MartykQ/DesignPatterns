using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;


namespace DDD.CarRentalLib.DomainModelLayer.Models
{   

    public enum CarStatus
    {
        Free = 0,
        Reserved = 1,
        Rented = 2
    }
    public class Car : AggregateRoot
    {
        public Car(Guid id, IDomainEventPublisher domainEventPublisher, Position currentPos,
            string registrationNumb, CarStatus status, Distance totalDist, Distance currentDistance) : base(id, domainEventPublisher)
        {
            this.CurrentPosition = currentPos;
            this.RegistrationNumber = registrationNumb;
            this.Status = status;
            this.TotalDistance = totalDist;
            this.CurrentDistance = currentDistance;
        }

        public Position CurrentPosition { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public CarStatus Status { get; protected set; }
        public Distance TotalDistance { get; protected set; }
        public Distance CurrentDistance { get; protected set; }


        public void DriveAway()
        {
            if (this.Status != CarStatus.Free) throw new Exception("Cannot drive away with rented car!");
            this.Status = CarStatus.Rented;
        }

        public void FreeUp()
        {
            this.Status = CarStatus.Free;
        }

        public void UpdatePosition(Position p)
        {
            this.CurrentPosition = p;
        }

    }
}
