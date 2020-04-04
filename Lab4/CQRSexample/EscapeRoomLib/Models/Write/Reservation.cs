using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EscapeRoom_CQRS.Models.Write
{
    public enum ReservationStatus
    {
        Created = 0,    // Reserwacja utworzona
        Canceled = 1,   // gracz anulował reserwacje
        Completed = 3,  // gracz zrealizował rezerwacje, tj. wszedł do pokoju zagadek
        Abandoned = 4,  // gracz nie przyszedł i nie anulował
    }

    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ReservationId { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public int Duration { get; set; }
        public decimal TotalAmount { get; set; }
        public ReservationStatus Status { get; set; }

        // związek 0..1 <--> 0..1 (jeden do jeden opcjonalny obustronnie) 
        [ForeignKey("VisitId")]
        public Visit Visit { get; set; }

        // związek 1 <--> 0..n (jeden do wielu obowiązkowy po stronie 1)
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        
    }
}
