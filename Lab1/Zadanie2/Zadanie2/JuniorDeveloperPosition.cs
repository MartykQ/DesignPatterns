using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie2
{
    class JuniorDeveloperPosition : DeveloperPosition
    {
        public static decimal payAmount = 5000;
        public override decimal calculateSalary(Developer dev)
        {
            return JuniorDeveloperPosition.payAmount;
        }

        public override void changeDeveloperPosition(Developer dev)
        {
            dev.DeveloperPosition = new SeniorDeveloperPosition();
        }
    }
}
