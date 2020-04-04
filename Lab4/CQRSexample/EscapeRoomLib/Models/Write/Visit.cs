using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EscapeRoom_CQRS.Models.Write
{
    public class Visit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid VisitId { get; set; }
        public DateTime EnterDateTime { get; set; }
        public DateTime? ExitDateTime { get; set; }
        public decimal TotalAmount { get; set; }

        // związek 0..1 <--> 0..1 (jeden do jeden opcjonalny obustronnie) 
        [ForeignKey("ReservationId")]
        public Reservation Reservation { get; set; }
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }
        public Room Room { get; set; }
        public Guid RoomId { get; set; }
    }
}
