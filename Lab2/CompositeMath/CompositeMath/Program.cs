using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeMath
{
    class Program
    {
        static void Main(string[] args)
        {
            // (7 * 2)
            Expression m1 = new Multiply(new ConstValue(7), new ConstValue(2));
            // (1 * 2)
            Expression m2 = new Multiply(new ConstValue(1), new ConstValue(2));
            Expression e = new Add(m1, m2);

            Console.WriteLine(e.DisplayExpression());
            Console.WriteLine(e.EvaluateExpression());

            Expression d1 = new Divide(new ConstValue(76), new ConstValue(12));
            Expression d2 = new Divide(new ConstValue(6), new ConstValue(12));
            Expression e2 = new Substract(d1, d2);
            Console.WriteLine(e2.DisplayExpression());
            Console.WriteLine(e2.EvaluateExpression());

            Expression e3 = new Add(e, e2);
            Console.WriteLine(e3.DisplayExpression());
            Console.WriteLine(e3.EvaluateExpression());

        }
    }
}
