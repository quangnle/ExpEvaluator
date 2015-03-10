using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    public class NumericContext : Context
    {

        public override IOperand Add(IOperand left, IOperand right)
        {
            var result = Convert.ToInt32(left.Content) + Convert.ToInt32(right.Content);
            return new NumericOperand(result.ToString());
        }

        public override IOperand Subtract(IOperand left, IOperand right)
        {
            var result = Convert.ToInt32(left.Content) - Convert.ToInt32(right.Content);
            return new NumericOperand(result.ToString());
        }

        public override IOperand Multiply(IOperand left, IOperand right)
        {
            var result = Convert.ToInt32(left.Content) * Convert.ToInt32(right.Content);
            return new NumericOperand(result.ToString());
        }

        public override IOperand Divide(IOperand left, IOperand right)
        {
            var result = Convert.ToInt32(left.Content) / Convert.ToInt32(right.Content);
            return new NumericOperand(result.ToString());
        }
    }
}
