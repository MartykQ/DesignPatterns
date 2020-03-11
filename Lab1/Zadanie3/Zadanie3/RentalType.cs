using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public abstract class RentalType
    {
        public abstract decimal CalculatePrice(Rental rental);
    }
}
