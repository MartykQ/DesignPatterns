using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.EscapeRoomLib.DomainModelLayer.Models
{
    public class Comment: AggregateRoot
    {
        public string Title { get; protected set; }
        public string Text { get; protected set; }
        public int Rating { get; protected set; }
        public DateTime Created { get; protected set; }
        public Guid RoomId { get; protected set; }
        public Guid PlayerId { get; protected set; }

        public Comment(Guid commentId, string title, string text, int rating, DateTime created, Guid roomId, Guid playerId, IDomainEventPublisher eventPublisher)
            :base(commentId, eventPublisher)
        {
            if (String.IsNullOrEmpty(title)) throw new ArgumentNullException("Comment title is null or empty");
            if (String.IsNullOrEmpty(text)) throw new ArgumentNullException("Comment text is null or empty");

            // moderacja
            Moderate(title, text);

            this.Title = title;
            this.Text = text;
            this.Created = created;
            this.Rating = rating;
            this.RoomId = roomId;
            this.PlayerId = playerId;
        }

        private void Moderate(string title, string text)
        {
            List<string> forbiddenWords = new List<string>() { "Pomidor" };

            if (forbiddenWords.Any(s => title.Contains(s))) throw new ArgumentNullException("Comment title contains forbidden words");
            if (forbiddenWords.Any(s => text.Contains(s))) throw new ArgumentNullException("Comment text contains forbidden words");
        }
    }
}