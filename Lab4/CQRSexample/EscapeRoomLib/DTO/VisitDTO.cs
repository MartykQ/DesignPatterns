using System;

namespace EscapeRoom_CQRS.DTO
{
    public class VisitDTO
    {
        public Guid VisitId { get; set; }
        public DateTime EnterDateTime { get; set; }
        public DateTime? ExitDateTime { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid PlayerId { get; set; }
        public string PlayerName { get; set; }
        public Guid RoomId { get; set; }
        public string RoomName { get; set; }
    }
}
