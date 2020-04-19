using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using DDD.EscapeRoomLib.DomainModelLayer.Events;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EscapeRoomLib.DomainModelLayer.Models
{
    public class Visit: AggregateRoot
    {
        public DateTime Started { get; protected set; }
        public DateTime? Finished { get; protected set; }
        public Money Total { get; protected set; }
        public Guid PlayerId { get; protected set; }
        public Guid RoomId { get; protected set; }
        
        private IDiscountPolicy _policy;
        
        public Visit(Guid visitId, Guid roomId, Guid playerId, DateTime started, IDomainEventPublisher eventPublisher)
            : base(visitId, eventPublisher)
        {
            this.Started = started;
            this.RoomId = roomId;
            this.PlayerId = playerId;
            this.Total = Money.Zero;
            
            this.DomainEventPublisher.Publish<VisitStartedEvent>(new VisitStartedEvent(this.Id, this.RoomId, this.PlayerId));
        }

        public void RegisterPolicy(IDiscountPolicy policy)
        {
            this._policy = policy ?? throw new ArgumentNullException("Empty discount policy");
        }

        public void StopVisit(DateTime finished, Money unitPrice)
        {
            // simple date walidation
            if (finished < Started)
                throw new Exception($"Exit date and time is earlier than enter date and time.");

            // set visit status
            this.Finished = finished;

            // calculate total
            var timeInMinutes = (this.Finished.Value - this.Started).Minutes;
            Total = unitPrice.MultiplyBy(timeInMinutes);

            // apply discount policy and recalculate total
            if (this._policy != null)
            {
                Money discount = this._policy.CalculateDiscount(this.Total, timeInMinutes, unitPrice);
                Total = (discount > Total) ? Money.Zero : Total - discount;
            }

            // publish event
            this.DomainEventPublisher.Publish<VisitFishedEvent>(new VisitFishedEvent(this.Id, this.RoomId, this.PlayerId));
        }

        public int GetTimeInMinutes()
        {
            if (!this.Finished.HasValue) throw new Exception("Not finished visit");

            return (this.Finished.Value - this.Started).Minutes;
        }
    }
}
