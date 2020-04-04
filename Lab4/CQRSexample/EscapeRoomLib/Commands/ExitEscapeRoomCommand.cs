using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Commands
{
    public class ExitEscapeRoomCommand : ICommand
    {
        public Guid VisitId { get; set; }
        public Guid EscapeRoomId { get; set; }
        public DateTime ExitTime { get; set; }
    }
}
