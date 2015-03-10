using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    public abstract class Context
    {
        public abstract IOperand Add(IOperand left, IOperand right);
        public abstract IOperand Subtract(IOperand left, IOperand right);
        public abstract IOperand Multiply(IOperand left, IOperand right);
        public abstract IOperand Divide(IOperand left, IOperand right);
    }
}
