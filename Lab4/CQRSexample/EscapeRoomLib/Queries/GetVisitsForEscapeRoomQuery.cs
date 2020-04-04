using System;

namespace EscapeRoom_CQRS.Queries
{
    public class GetVisitsForEscapeRoomQuery : IQuery
    {
        public Guid RoomId { get; set; }
    }
}
