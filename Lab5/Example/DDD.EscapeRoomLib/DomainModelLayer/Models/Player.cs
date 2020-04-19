using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using DDD.EscapeRoomLib.DomainModelLayer.Events;
using DDD.EscapeRoomLib.DomainModelLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EscapeRoomLib.DomainModelLayer.Models
{
    public enum PlayerStatus
    {
        Active = 0,  // Gracz aktywny
        Banned = 1  // Gracz zbanowany
    }

    public class Player: AggregateRoot
    {
        public string Name { get; protected set; }
        public Email Email { get; protected set; }
        public PlayerStatus Status { get; protected set; }

        public Player(Guid playerId, string name, string email, IDomainEventPublisher eventPublisher)
            : base(playerId, eventPublisher)
        {
            if (String.IsNullOrEmpty(name)) throw new Exception("Player name is null or empty");
            if (String.IsNullOrEmpty(email)) throw new Exception("Email name is null or empty");

            Name = name;
            Email = new Email(email);
            Status = PlayerStatus.Active;

            this.DomainEventPublisher.Publish(new PlayerCreatedEvent(this.Id, this.Name.ToString(), this.Email.Value));
        }
    }
}
