using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class Rental
    {
        private string _owner;
        private RentalType _rentalType;
        private int _rentalTime;
        private decimal _unitPrice;
        public string Owner { get => _owner; set => _owner = value; }
        public RentalType RentalType { get => _rentalType; set => _rentalType = value; }
        public int RentalTime { get => _rentalTime; set => _rentalTime = value; }
        public decimal UnitPrice { get => _unitPrice; set => _unitPrice = value; }

        public Rental(string owner, int duration)
        {
            this._owner = owner;
            this._rentalTime = duration;
        }

        public decimal CalculatePrice()
        {
            return _rentalType.CalculatePrice(this);
        }

        public void ChangeRentalType()
        {
            this._rentalType.ChangeRentalType(this);
        }


    }
}
