using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.Models.Write
{
    public class Rental
    {
        private Car _car;
        private int _rentalID;
        private DateTime _startDate;
        private DateTime _endDate;
        private double _total;
        private Driver _driver;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RentalID { get => _rentalID; set => _rentalID = value; }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public double Total { get => _total; set => _total = value; }
        internal Car Car { get => _car; set => _car = value; }
        internal Driver Driver { get => _driver; set => _driver = value; }

        public Rental()
        {

        }
    
    
    
    }
}
