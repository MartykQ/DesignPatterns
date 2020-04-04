using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Queries
{
    public class GetReservationsForEscapeRoomQuery: IQuery
    {
        public Guid RoomId { get; set; }
    }
}
