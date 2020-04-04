using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.DTO
{
    public class RoomDTO
    {
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public EscapeRoomStatus Level { get; set; }
        public EscapeRoomStatus Status { get; set; }
    }
}
