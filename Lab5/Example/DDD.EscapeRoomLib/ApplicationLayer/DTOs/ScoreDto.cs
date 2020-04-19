using System;

namespace DDD.EscapeRoomLib.ApplicationLayer.Dto
{
    public class ScoreDto
    {
        public string Player { get; set; }
        public int TimeInMinutes { get; set; }
        public DateTime Created { get; set; }
    }
}