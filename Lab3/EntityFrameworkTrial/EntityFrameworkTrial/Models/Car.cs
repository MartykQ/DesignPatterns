using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTrial
{
    public class Car
    {
        private int _id;
        private string _registrationNumber;
        private float _xPosition;
        private float _yPosition;
        private float _currentDistance;
        private float _totalDistance;
        private int _status;

        public int Id { get => _id; set => _id = value; }
        public string RegistrationNumber { get => _registrationNumber; set => _registrationNumber = value; }
        public float XPosition { get => _xPosition; set => _xPosition = value; }
        public float YPosition { get => _yPosition; set => _yPosition = value; }
        public float CurrentDistance { get => _currentDistance; set => _currentDistance = value; }
        public float TotalDistance { get => _totalDistance; set => _totalDistance = value; }
        public int Status { get => _status; set => _status = value; }

        public Car()
        {

        }

        public override string ToString()
        {
            return $"Car: {RegistrationNumber}, current distance: {CurrentDistance}";
        }

    }
}
