using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Commands
{
    public class UnbanPlayerCommand : ICommand
    {
        public Guid PlayerId { get; set; }
    }
}
