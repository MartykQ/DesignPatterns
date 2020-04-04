using EscapeRoom_CQRS.Models;
using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeRoom_CQRS.DTO
{
    public class ReservationDTO
    {
        public Guid ReservationId { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public int Duration { get; set; }
        public decimal TotalAmount { get; set; }
        public ReservationStatus Status { get; set; }
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
    }
}
