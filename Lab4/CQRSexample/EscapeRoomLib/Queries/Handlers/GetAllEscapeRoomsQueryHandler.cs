using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EscapeRoom_CQRS.Models.Write;
using EscapeRoom_CQRS.Persistence;

namespace EscapeRoom_CQRS.Queries.Handlers
{
    public class GetAllEscapeRoomsQueryHandler: QueryHandlerBase, IQueryHandler<GetAllEscapeRoomsQuery, List<RoomDTO>>
    {
        public GetAllEscapeRoomsQueryHandler(EscapeRoomContext context)
            : base(context)
        { }

        public List<RoomDTO> Execute(GetAllEscapeRoomsQuery query)
        {
            var rooms = this._context.Rooms
                .Select(r => new RoomDTO() 
                {
                    RoomId = r.RoomId,
                    Name = r.Name,
                    Level = r.Level,
                    Status = r.Status,
                    UnitPrice = r.UnitPrice
                });

            return rooms.ToList();
        }
    }
}
