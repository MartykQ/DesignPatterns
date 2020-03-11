using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    class GrowingRentalType : RentalType
    {

        public static decimal percentageDiscount = Convert.ToDecimal(0.12);
        public override decimal CalculatePrice(Rental rental)
        {

            List<decimal> priceHistory = new List<decimal>();
            decimal calculatedPrice = 0;

            for (int i=1; i <= rental.RentalTime; i++)
            {
                Console.WriteLine(i);
                // Day one
                if(i == 1)
                {
                    calculatedPrice += rental.UnitPrice;
                    priceHistory.Add(calculatedPrice);
                } 
                // Second and next days
                else
                {
                    decimal todayPrice = (1-percentageDiscount)*priceHistory[priceHistory.Count - 1];
                    priceHistory.Add(todayPrice);
                    calculatedPrice += todayPrice;
                }
            }
            return calculatedPrice;
        }

    }
}
