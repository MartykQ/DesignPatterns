using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EscapeRoom_CQRS.Models.Write
{
    public enum EscapeRoomStatus
    {
        Free = 0,
        Busy = 1,
        Closed = 2
    }

    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public EscapeRoomStatus Level { get; set; }
        public EscapeRoomStatus Status { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
