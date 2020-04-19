using System;
using System.Collections.Generic;
using System.Text;
using DDD.Base.DomainModelLayer.Events;
using DDD.EscapeRoomLib.DomainModelLayer.Models;

namespace DDD.EscapeRoomLib.DomainModelLayer.Factories
{

    public class VisitFactory
    {
        private IDomainEventPublisher _domainEventPublisher;

        public VisitFactory(IDomainEventPublisher domainEventPublisher)
        {
            this._domainEventPublisher = domainEventPublisher;
        }

        public Visit Create(Guid visitId, DateTime enterDateTime, Room room, Player player)
        {
            CheckIfPlayerIsActive(player);
            CheckIfRoomIsFree(room);

            return new Visit(visitId, room.Id, player.Id, enterDateTime, this._domainEventPublisher);
        }

        private void CheckIfPlayerIsActive(Player player)
        {
            if (player.Status != PlayerStatus.Active) throw new Exception($"Player '{player.Id}' is not active");
        }

        private void CheckIfRoomIsFree(Room room)
        {
            if (room.Status != EscapeRoomStatus.Free) throw new Exception($"Room '{room.Id}' is not free");
        }
    }
}
