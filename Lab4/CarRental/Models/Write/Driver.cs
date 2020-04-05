using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarRental.Models.Write
{
    public class Driver
    {
        private int _driverId;
        private string _licenseNumber;
        private string _firstName;
        private string _lastName;

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DriverId { get => _driverId; set => _driverId = value; }
        public string LicenseNumber { get => _licenseNumber; set => _licenseNumber = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }

        public Driver()
        {

        }
        public Driver(string license, string first, string last)
        {
            this._licenseNumber = license;
            this._firstName = first;
            this._lastName = last;
        }

    }
}
