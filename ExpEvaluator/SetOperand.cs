using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    public class SetOperand : IOperand
    {
        public string Content { get; set; }
        public OperandType OpType { get; set; }

        public SetOperand(string content)
        {
            Content = content;
            OpType = OperandType.Set;
        }
    }
}
