using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Commands
{
    public class MakeReservationCommand: ICommand
    {
        public Guid ReservationId { get; set; }
        public Guid PlayerId { get; set; }
        public Guid EscapeRoomId { get; set; }
        public DateTime Start { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int Duration { get; set; }
    }
}
