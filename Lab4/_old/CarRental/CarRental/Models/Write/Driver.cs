using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Models.Write
{
    class Driver
    {

        private DateTime _startDateTime;
        private DateTime _stopDateTime;
        private double _total;

        public DateTime StartDateTime { get => _startDateTime; set => _startDateTime = value; }
        public DateTime StopDateTime { get => _stopDateTime; set => _stopDateTime = value; }
        public double Total { get => _total; set => _total = value; }


        public Driver()
        {

        }


    }
}
