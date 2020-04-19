using System;

namespace DDD.EscapeRoomLib.ApplicationLayer.Dto
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }

        public Guid RoomId { get; set; }
        public Guid PlayerId { get; set; }

    }
}