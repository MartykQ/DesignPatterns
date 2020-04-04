using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Reservation GetReservationWithDependents(Guid reservationId);
        bool IsRoomBookedForDate(Guid roomId, DateTime start, int duration);
    }
}
