using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EscapeRoom_CQRS.Models.Write
{
    public enum PlayerStatus
    {
        Active = 0,  // Gracz aktywny
        Banned = 1  // Gracz zbanowany
    }

    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PlayerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public PlayerStatus Status { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
