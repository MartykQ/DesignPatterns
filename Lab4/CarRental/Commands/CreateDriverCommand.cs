using CarRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Commands
{
    public class CreateDriverCommand : ICommand
    {
        public int Id { get; set; }
        public string License { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
