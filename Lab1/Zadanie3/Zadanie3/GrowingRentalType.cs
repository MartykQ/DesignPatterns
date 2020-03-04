using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    class GrowingRentalType : RentalType
    {

        public static double percentageDiscount;
        public override decimal CalculatePrice(Rental rental)
        {
            decimal calculatedPrice = 0;

            calculatedPrice += rental.UnitPrice;

            for (int i=1; i <= rental.RentalTime; i++)
            {

            }

            
        }

        public override void ChangeRentalType(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
