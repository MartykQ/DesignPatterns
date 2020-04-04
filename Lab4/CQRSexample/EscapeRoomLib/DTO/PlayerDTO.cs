using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.DTO
{
    public class PlayerDTO
    {
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public PlayerStatus Status { get; set; }
    }
}
