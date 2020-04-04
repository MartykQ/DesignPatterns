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
    public class CancelReservationCommandHandler: CommandHandlerBase, ICommandHandler<CancelReservationCommand>
    {
        public CancelReservationCommandHandler(IEscapeRoomUnitOfWork unitOfWork)
            : base(unitOfWork) { }
        
        public void Execute(CancelReservationCommand command)
        {
            Reservation reservation = this._unitOfWork.ReservationRepository.Get(command.ReservationId);
            if (reservation == null)
                throw new Exception($"Could not find reservation '{command.ReservationId}'.");
            if (reservation.Status != ReservationStatus.Created)
                throw new Exception($"Reservation '{reservation.ReservationId}' has status '{reservation.Status}'.");

            // business logic
            reservation.Status = ReservationStatus.Canceled;

            // update ReservationView - read stack
            ReservationView reservationView = this._unitOfWork.ReservationViewRepository.Get(command.ReservationId);
            if (reservationView != null)
                reservationView.Status = ReservationStatus.Canceled;

            // commit changes
            this._unitOfWork.Commit();
        }
    }
}
