using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    public class SetContext : Context
    {
        public override IOperand Add(IOperand left, IOperand right)
        {
            var l = left.Content.Replace("[", "").Replace("]","");
            var r = right.Content.Replace("[", "").Replace("]", "");
            return new SetOperand("[" + l + "," + r + "]");
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
