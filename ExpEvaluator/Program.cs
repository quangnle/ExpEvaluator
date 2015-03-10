using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = @"[11] + (7+9-12) + 4 * 1/1 + [2,3,11] + ""abc""";
            //var expression = @"(7+9-12) + 4 * 1/1";

            expression = "1 + 2 * (3 - 4)";

            expression = "+ 1 * 2 - 3 4";
            

            Console.WriteLine(expression);

            Console.WriteLine(Evaluator.ToPrefixString(expression));
            Console.WriteLine(Evaluator.Evaluate(expression).Content);
            Console.Read();
        }
    }
}
