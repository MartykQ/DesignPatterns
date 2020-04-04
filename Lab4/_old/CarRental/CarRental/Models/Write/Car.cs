using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Models.Write
{   

    public enum CarStatus
    {
        Free = 0,
        Reserved = 1,
        Rented = 2

    }
    class Car
    {
        private int _id;
        private string _registrationNumber;
        private double _xPosition;
        private double _yPosition;
        private double _currentDistance;
        private double _totalDistance;
        private CarStatus _status;

        public int Id { get => _id; set => _id = value; }
        public string RegistrationNumber { get => _registrationNumber; set => _registrationNumber = value; }
        public double XPosition { get => _xPosition; set => _xPosition = value; }
        public double YPosition { get => _yPosition; set => _yPosition = value; }
        public double CurrentDistance { get => _currentDistance; set => _currentDistance = value; }
        public double TotalDistance { get => _totalDistance; set => _totalDistance = value; }
        public CarStatus Status { get => _status; set => _status = value; }
    
        public Car()
        {

        }
    
    
    }
}
