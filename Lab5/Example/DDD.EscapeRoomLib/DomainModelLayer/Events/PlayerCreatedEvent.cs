using DDD.Base.DomainModelLayer.Events;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EscapeRoomLib.DomainModelLayer.Events
{
    public class PlayerCreatedEvent : IDomainEvent
    {
        public Guid PlayerId { get; private set; }
        public string Name { get; private set; }

        public string Email { get; private set; }


        public PlayerCreatedEvent(Guid id, string name, string email)
        {
            this.PlayerId = id;
            this.Name = name;
            this.Email = email;
        }
            

    }

    public class NewScoreEvent : IDomainEvent
    {
        public Guid PlayerId { get; private set; }
        public int Minutes { get; set; }
        public DateTime Created { get; set; }
    }

    public class VisitStartedEvent : IDomainEvent
    {
        public Guid RoomId { get; private set; }
        public Guid PlayerId { get; private set; }
        public Guid VisitId { get; private set; }

        public VisitStartedEvent(Guid visitId, Guid roomId, Guid playerId)
        {
            this.VisitId = visitId;
            this.RoomId = roomId;
            this.PlayerId = playerId;
        }
    }

    public class VisitFishedEvent : IDomainEvent
    {
        public Guid RoomId { get; private set; }
        public Guid PlayerId { get; private set; }
        public Guid VisitId { get; private set; }

        public VisitFishedEvent(Guid visitId, Guid roomId, Guid playerId)
        {
            this.VisitId = visitId;
            this.RoomId = roomId;
            this.PlayerId = playerId;
        }
    }
}
