using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DTO
{
    public class RentalDTO
    {
        public int RentalId { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime stoptDateTime { get; set; }

        public double Total { get; set; }

    }
}
