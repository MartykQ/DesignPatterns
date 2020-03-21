using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeMath
{
    public interface IComponent
    {
        decimal EvaluateExpression();
        string DisplayExpression();
    }
}
