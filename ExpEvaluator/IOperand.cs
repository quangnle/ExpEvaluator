﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    public interface IOperand : IToken
    {
        OperandType OpType { get; set; }
    }
}
