using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Commands
{
    public class CreateEscapeRoomCommand : ICommand
    {
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public EscapeRoomStatus Level { get; set; }
    }
}
