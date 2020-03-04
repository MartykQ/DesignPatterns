using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie2
{
    class SeniorDeveloperPosition : DeveloperPosition
    {

        public static decimal payAmount = 9000;
        public override decimal calculateSalary(Developer dev)
        {
            return SeniorDeveloperPosition.payAmount + 50 * dev.AdditionalHours;
        }

        public override void changeDeveloperPosition(Developer dev)
        {
            dev.DeveloperPosition = new ExpertDeveloperPosition();
        }
    }
}
