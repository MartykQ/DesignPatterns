using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Commands
{
    public class EnterEscapeRoomCommand : ICommand
    {
        public Guid VisitId { get; set; }
        public Guid ReservationId { get; set; }
        public DateTime EnterTime { get; set; }
    }
}
