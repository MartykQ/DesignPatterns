using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    class StandardRentalType : RentalType
    {
        public static double percentalDiscount = 0.15;
        public override decimal CalculatePrice(Rental rental)
        {
            return (rental.RentalTime * rental.UnitPrice)*(1-Convert.ToDecimal(percentalDiscount));
        }

        public override void ChangeRentalType(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
