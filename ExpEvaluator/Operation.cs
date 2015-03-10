using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    public class Operation : IToken
    {
        public string Content { get; set; }

        public Operation(string content)
        {
            Content = content;
        }
    }
}
