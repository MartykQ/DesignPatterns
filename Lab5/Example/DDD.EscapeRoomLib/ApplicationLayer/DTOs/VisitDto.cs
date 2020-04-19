using System;
using System.Collections.Generic;

namespace DDD.EscapeRoomLib.ApplicationLayer.Dto
{
    public class VisitDto
    {
        public Guid Id { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Finished { get; set; }
        public int TimeInMinutes { get; set; }
        public decimal Total { get; set; }
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
    }
}