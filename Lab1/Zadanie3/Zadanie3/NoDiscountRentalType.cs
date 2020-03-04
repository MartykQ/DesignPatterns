using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    class NoDiscountRentalType : RentalType
    {
        public override decimal CalculatePrice(Rental rental)
        {
            return rental.RentalTime * rental.UnitPrice;
        }

        public override void ChangeRentalType(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
