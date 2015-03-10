using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    public class StringContext : Context
    {
        public override IOperand Add(IOperand left, IOperand right)
        {
            return new StringOperand(left.Content + right.Content);
        }

        public override IOperand Subtract(IOperand left, IOperand right)
        {
            throw new NotImplementedException();
        }

        public override IOperand Multiply(IOperand left, IOperand right)
        {
            throw new NotImplementedException();
        }

        public override IOperand Divide(IOperand left, IOperand right)
        {
            throw new NotImplementedException();
        }
    }
}
