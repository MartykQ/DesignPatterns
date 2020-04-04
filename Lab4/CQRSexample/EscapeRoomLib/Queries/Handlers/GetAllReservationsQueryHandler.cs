using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscapeRoom_CQRS.Persistence;

namespace EscapeRoom_CQRS.Queries.Handlers
{
    public class GetAllReservationsQueryHandler: QueryHandlerBase, IQueryHandler<GetAllReservationsQuery, List<ReservationDTO>>
    {
        public GetAllReservationsQueryHandler(EscapeRoomContext context)
            : base(context)
        { }

        public List<ReservationDTO> Execute(GetAllReservationsQuery query)
        {
            var reservationViews = this._context.ReservationViews
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

            // gdyby nie było oddzielnej tabeli ReservationView,
            // wówczas należałoby zrobić kwerendę z dwoma joinami
            // która jest zdecywoanie wolniejsza od kwerendy na jednej tabeli
            // przykład takiej kwerendy poniżej
            //var reservationViews = (from r in this._context.Reservations
            //                        join e in this._context.EscapeRooms on r.RoomId equals e.RoomId
            //                        join p in this._context.Players on r.PlayerId equals p.PlayerId
            //                        select new ReservationDTO
            //                        {
            //                            ReservationId = r.ReservationId,
            //                            ReservationDateTime = r.ReservationDateTime,
            //                            StartDateTime = r.StartDateTime,
            //                            Duration = r.Duration,
            //                            Status = r.Status,
            //                            TotalAmount = r.TotalAmount,
            //                            RoomId = e.RoomId,
            //                            RoomName = e.Name,
            //                            PlayerId = p.PlayerId,
            //                            PlayerName = p.Name
            //                        });

        }
    }
}

// Jak pisać join
// https://entityframework.net/knowledge-base/22907820/lambda-expression-join-multiple-tables-with-select-and-where-clause
// https://stackoverflow.com/questions/21051612/entity-framework-join-3-tables
