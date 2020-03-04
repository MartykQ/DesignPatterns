using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie2
{
    class ExpertDeveloperPosition : DeveloperPosition
    {
        public static decimal payAmount = 15000;


        public override decimal calculateSalary(Developer dev)
        {
            decimal firstPayAmount = ExpertDeveloperPosition.payAmount + 100 * dev.AdditionalHours;
            decimal multiplier = Convert.ToDecimal(0.03);
            return firstPayAmount +  multiplier* firstPayAmount;
        }

        public override void changeDeveloperPosition(Developer dev)
        {
            Console.WriteLine("you are already expert");
        }
    }
}
