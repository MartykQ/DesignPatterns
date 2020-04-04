using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Read;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeRoom_CQRS.Commands.Handlers
{
    public class EnterEscapeRoomCommandHandler: CommandHandlerBase, ICommandHandler<EnterEscapeRoomCommand>
    {
        public EnterEscapeRoomCommandHandler(IEscapeRoomUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public void Execute(EnterEscapeRoomCommand command)
        {
            Reservation reservation = this._unitOfWork.ReservationRepository.GetReservationWithDependents(command.ReservationId);
            if (reservation == null)
                throw new Exception($"Could not find reservation '{command.ReservationId}'.");
            if (reservation.Status != ReservationStatus.Created)
                throw new Exception($"Reservation '{reservation.ReservationId}' has status '{reservation.Status}'.");

            Room room = reservation.Room;
            if (room == null)
                throw new Exception($"Could not find room '{reservation.RoomId}'.");
            if (room.Status != EscapeRoomStatus.Free )
                throw new Exception($"Room '{reservation.RoomId}' is not free.");

            Player player = reservation.Player;
            if (player == null)
                throw new Exception($"Could not find player '{player.Name}'.");
            if (player.Status == PlayerStatus.Banned)
                throw new Exception($"Player '{player.Name}' is banned.");

            reservation.Status = ReservationStatus.Completed;
            room.Status = EscapeRoomStatus.Busy;
            Visit visit = new Visit()
            {
                EnterDateTime = command.EnterTime,
                Player = player,
                Room = room,
                TotalAmount = reservation.TotalAmount,
                VisitId = command.VisitId,
                Reservation = reservation,
            };
            this._unitOfWork.VisitRepository.Insert(visit);

            // create visit view - read stack
            VisitView visitView = new VisitView()
            {
                VisitId = visit.VisitId,
                EnterDateTime = visit.EnterDateTime,
                TotalAmount = visit.TotalAmount,
                PlayerId = player.PlayerId,
                PlayerName = player.Name,
                RoomId = room.RoomId,
                RoomName = room.Name,
            };
            this._unitOfWork.VisitViewRepository.Insert(visitView);

            this._unitOfWork.Commit();
        }
    }
}
