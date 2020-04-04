using EscapeRoom_CQRS.Models.Write;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EscapeRoom_CQRS.Models.Read
{
    public class ReservationView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
