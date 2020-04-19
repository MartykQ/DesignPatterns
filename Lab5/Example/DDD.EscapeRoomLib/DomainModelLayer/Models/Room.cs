﻿using DDD.Base.DomainModelLayer.Events;
using DDD.Base.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.EscapeRoomLib.DomainModelLayer.Models
{
    public enum EscapeRoomStatus
    {
        Free = 0,
        Busy = 1,
        Closed = 2
    }

    public enum EscapeRoomLevel
    {
        Beginner = 0,
        Easy,
        Normal,
        Hard,
    }

    public class Room: AggregateRoot
    {
        public string Name { get; protected set; }
        public Money UnitPrice { get; protected set; }
        public double AverageRating { get; protected set; }
        public EscapeRoomLevel Level { get; protected set; }
        public EscapeRoomStatus Status { get; protected set; }

        // założenie: przechowujemy 3 najlepsze wyniki
        private List<Score> _scores;
        public IEnumerable<Score> Scores
        {
            get { return _scores.AsReadOnly(); }
        }

        public Room(Guid roomId, string name, EscapeRoomLevel level, Money unitPrice, IDomainEventPublisher eventPublisher)
            : base(roomId, eventPublisher)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Room name is empty.");
            if (unitPrice < Money.Zero) throw new ArgumentNullException("Unit price is less then zero.");

            this.Name = name;
            this.Level = level;
            this.AverageRating = 0;
            this.UnitPrice = unitPrice;
            this.Status = EscapeRoomStatus.Free;
            this._scores = new List<Score>();
        }

        public void UpdateRating(double averageRating)
        {
            this.AverageRating = averageRating;
        }

        public void EnterTheRoom()
        {
            if (this.Status != EscapeRoomStatus.Free)
                throw new Exception($"Room '{this.Name}' is not free.");

            this.Status = EscapeRoomStatus.Busy;
        }

        public void ExitTheRoom(Guid playerId, string playerName, int timeInMinutes, DateTime created)
        {
            // change room status and update current score
            this.Status = EscapeRoomStatus.Free;
            this.UpdateScore(playerId, playerName, timeInMinutes, created);
        }

        private void UpdateScore(Guid playerId, string playerName, int timeInMinutes, DateTime created)
        {
            // add new score
            Score s = new Score(playerId, playerName, timeInMinutes, created);
            this._scores.Add(s);

            // sort scores
            this._scores.Sort((s1, s2) => s1.Compare(s2));

            // remove last element
            if (this._scores.Count > 3) this._scores.RemoveRange(3, 1);
        }
    }
}
