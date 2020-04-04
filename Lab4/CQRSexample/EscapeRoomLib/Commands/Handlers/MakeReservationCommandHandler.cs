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
    public class MakeReservationCommandHandler: CommandHandlerBase, ICommandHandler<MakeReservationCommand>
    {
        public MakeReservationCommandHandler(IEscapeRoomUnitOfWork unitOfWork)
            : base(unitOfWork) { }

        public void Execute(MakeReservationCommand command)
        {
            Player player = this._unitOfWork.PlayerRepository.Get(command.PlayerId);
            if (player == null)
                throw new Exception($"Could not find player '{command.PlayerId}'.");
            if (player.Status == PlayerStatus.Banned)
                throw new Exception($"Player '{command.PlayerId}' is banned.");
            
            Room room = this._unitOfWork.RoomRepository.Get(command.EscapeRoomId);
            if (room == null)
                throw new Exception($"Could not find room '{command.EscapeRoomId}'.");

            // check if room is available
            bool isRoomBookedForDate = this._unitOfWork.ReservationRepository.IsRoomBookedForDate(command.EscapeRoomId, command.Start, command.Duration);
            if (isRoomBookedForDate)
                throw new Exception($"Room '{command.EscapeRoomId}' is booked for the time and date '{command.Start}'.");

            // calculate cost and create reservation (stos Write)
            var total = (decimal)command.Duration * room.UnitPrice;
            var reservation = new Reservation()
            {
                ReservationId = command.ReservationId,
                StartDateTime = command.Start,
                Duration = command.Duration,
                ReservationDateTime = command.ReservationDateTime,
                TotalAmount = total,
                Status = ReservationStatus.Created,
                Player = player,
                Room = room
            };
            this._unitOfWork.ReservationRepository.Insert(reservation);

            // update read stack
            var reservationView = new ReservationView()
            {
                ReservationId = reservation.ReservationId,
                StartDateTime = reservation.StartDateTime,
                Duration = reservation.Duration,
                ReservationDateTime = reservation.ReservationDateTime,
                TotalAmount = total,
                Status = reservation.Status,
                PlayerName = player.Name,
                PlayerId = player.PlayerId,
                RoomName = room.Name,
                RoomId = room.RoomId,
            };
            this._unitOfWork.ReservationViewRepository.Insert(reservationView);

            this._unitOfWork.Commit();
        }
    }
}
