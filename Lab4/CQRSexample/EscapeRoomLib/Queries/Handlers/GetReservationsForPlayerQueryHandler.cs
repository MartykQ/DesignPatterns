using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscapeRoom_CQRS.Persistence;

namespace EscapeRoom_CQRS.Queries.Handlers
{
    public class GetReservationsForPlayerQueryHandler: QueryHandlerBase, IQueryHandler<GetReservationsForPlayerQuery, List<ReservationDTO>>
    {
        public GetReservationsForPlayerQueryHandler(EscapeRoomContext context)
            : base(context)
        { }

        public List<ReservationDTO> Execute(GetReservationsForPlayerQuery query)
        {
            var reservationViews = this._context.ReservationViews
                .Where(r => r.PlayerId == query.PlayerId)
                .Select(r => new ReservationDTO()
                {
                    ReservationId = r.ReservationId,
                    ReservationDateTime = r.ReservationDateTime,
                    StartDateTime = r.StartDateTime,
                    Duration = r.Duration,
                    TotalAmount = r.TotalAmount,
                    Status = r.Status,
                    PlayerId = r.PlayerId,
                    PlayerName = r.PlayerName,
                    RoomId = r.RoomId,
                    RoomName = r.RoomName,
                });

            return reservationViews.ToList();
        }
    }
}
