using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EscapeRoom_CQRS.Persistence
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(EscapeRoomContext context)
            : base(context) { }

        // returns Reservation with dependant objects (EscapeRoom and Player)
        public Reservation GetReservationWithDependents(Guid reservationId)
        {
            var reservation = this._context.Set<Reservation>()
                        .Where(r => r.ReservationId == reservationId)
                        .Include(r => r.Room)
                        .Include(r => r.Player)
                        .FirstOrDefault();

            return reservation;
        }

        public bool IsRoomBookedForDate(Guid roomId, DateTime start, int duration)
        {
            // to do
            return false;
        }
    }
}
