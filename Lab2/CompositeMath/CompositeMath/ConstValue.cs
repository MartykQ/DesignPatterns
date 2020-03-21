using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeMath
{
    class ConstValue : IComponent
    {

        private decimal _value;
        public decimal Value { get => _value; set => _value = value; }

        public ConstValue(decimal value)
        {
            this._value = value;
        }
        public string DisplayExpression()
        {
            return this._value.ToString();
        }

        public decimal EvaluateExpression()
        {
            return this._value;
        }
    }
}
