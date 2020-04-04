using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.Commands
{
    public class CreatePlayerCommand : ICommand
    {
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public PlayerStatus Status { get; set; }
    }
}
