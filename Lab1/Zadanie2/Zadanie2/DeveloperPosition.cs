using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie2
{
    public abstract class DeveloperPosition
    {
        public abstract decimal calculateSalary(Developer dev);
        public abstract void changeDeveloperPosition(Developer dev);
    }
}
