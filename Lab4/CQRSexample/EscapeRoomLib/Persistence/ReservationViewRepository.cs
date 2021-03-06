﻿using EscapeRoom_CQRS.Interfaces;
using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Read;

namespace EscapeRoom_CQRS.Persistence
{
    public class ReservationViewRepository : Repository<ReservationView>, IReservationViewRepository
    {
        public ReservationViewRepository(EscapeRoomContext context)
            : base(context) { }
    }
}
