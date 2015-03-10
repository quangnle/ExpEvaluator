using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    public class StringOperand : IOperand
    {
        public string Content { get; set; }
        public OperandType OpType { get; set; }

        public StringOperand(string content)
        {
            Content = content;
            OpType = OperandType.String;
        }
    }
}
