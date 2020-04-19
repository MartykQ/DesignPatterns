using System;

namespace DDD.EscapeRoomLib.ApplicationLayer.Dto
{
    public enum PlayerStatusDto
    {
        Active = 0,  // Gracz aktywny
        Banned = 1  // Gracz zbanowany
    }

    public class PlayerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public PlayerStatusDto Status { get; set; }
    }
}