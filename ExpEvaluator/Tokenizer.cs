using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    public class Tokenizer
    {
        /// <summary>
        /// Tokenizing ignores bad input
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public static List<IToken> Tokenize(string expression)
        {
            var result = new List<IToken>();
            var isString = false;
            var isSet = false;

            var index = 0;
            var token = "";

            while ( index < expression.Length)
            {
                var c = expression[index];

                if (c >= '0' && c <= '9')
                {
                    token += c;
                }
                else if (c == '"')
                {
                    isString = !isString;
                    if (isString == false)
                    {
                        result.Add( new StringOperand(token));
                        token = "";
                    }
                }
                else if (c == '[')
                {
                    isSet = true;
                }
                else if (c == ']')
                {
                    isSet = false;
                    result.Add(new SetOperand(token));
                    token = "";
                }
                else
                {
                    if (isString || isSet) 
                    {
                        token += c;
                    }
                    else 
                    {
                        if (("()+-*/").IndexOf(c) >= 0)
                        {
                            if (token != "")
                                result.Add(new NumericOperand(token));
                            result.Add(new Operation(c + ""));
                            token = "";
                        }
                    }
                }
                index++;
            }

            if (token != "")
                result.Add(new NumericOperand(token));
            return result;
        }
    }
}
