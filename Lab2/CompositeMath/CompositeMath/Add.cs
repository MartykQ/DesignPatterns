﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeMath
{
    class Add : Expression
    {
        public Add(IComponent a, IComponent b) : base(a, b)
        {

        }

        public override string DisplayExpression()
        {
            return $"({this.A.DisplayExpression()} + {this.B.DisplayExpression()})";
        }

        public override decimal EvaluateExpression()
        {
            return this.A.EvaluateExpression() + this.B.EvaluateExpression();
        }
    }
}
