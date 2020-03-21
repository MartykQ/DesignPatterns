using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeMath
{
    public abstract class Expression : IComponent
    {
        private IComponent _a;
        private IComponent _b;

        public IComponent A { get => _a; set => _a = value; }
        public IComponent B { get => _b; set => _b = value; }

        public Expression(IComponent a, IComponent b)
        {
            this._a = a;
            this._b = b;
        }

        public abstract string DisplayExpression();
        public abstract decimal EvaluateExpression();
    }
}
