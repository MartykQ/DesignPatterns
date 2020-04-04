using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Commands
{
    public class CancelReservationCommand : ICommand
    {
        public Guid ReservationId { get; set; }
    }
}
