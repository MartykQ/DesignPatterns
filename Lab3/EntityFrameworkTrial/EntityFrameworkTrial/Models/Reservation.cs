using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTrial
{
    public class Reservation
    {

        private int _reservationId;
        private DateTime _reservationDateTime;
        private int _status;
        private Car _car;
        
        public Reservation()
        {

        }

        public int ReservationId { get => _reservationId; set => _reservationId = value; }
        public DateTime ReservationDateTime { get => _reservationDateTime; set => _reservationDateTime = value; }
        public int Status { get => _status; set => _status = value; }
        public Car Car { get => _car; set => _car = value; }

        public int MinutesSinceCreated { get => (int)this.ReservationDateTime.Subtract(DateTime.Now).TotalMinutes; }

        public override string ToString()
        {
            return $"Rezerwacja {this.ReservationId} || Status: {this.Status}";
        }
    }
}
