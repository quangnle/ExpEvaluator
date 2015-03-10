using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpEvaluator
{
    public class Evaluator
    {
        private static Dictionary<int, Context> _context;

        public static IOperand Evaluate(string expression)
        {
            InitContext();

            var tokens = Tokenizer.Tokenize(expression);
            var list = GetPrefixList(tokens);
            var stack = new Stack<IOperand>();

            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if (item is IOperand)
                    stack.Push(item as IOperand);
                else
                {
                    var right = stack.Pop();
                    var left = stack.Pop();

                    var chosenContext = _context[Math.Max((int)left.OpType, (int)right.OpType)];

                    if (item.Content == "+")
                        stack.Push(chosenContext.Add(left, right));
                    else if (item.Content == "-")
                        stack.Push(chosenContext.Subtract(left, right));
                    else if (item.Content == "*")
                        stack.Push(chosenContext.Multiply(left, right));
                    else 
                        stack.Push(chosenContext.Divide(left, right));
                }
            }

            return stack.Pop();
        }

        private static void InitContext() {
            _context = new Dictionary<int, Context>();
            _context.Add(0, new NumericContext());
            _context.Add(1, new SetContext());
            _context.Add(2, new StringContext());
        }

        private static int GetPriority(Operation op)
        {
            if (op.Content == "+" || op.Content == "-") 
                return 1;
            if (op.Content == "*" || op.Content == "/")
                return 2;
            return 3;
        }

        private static List<IToken> GetPrefixList(List<IToken> tokens)
        {
            List<IToken> tokenList = new List<IToken>();
            Stack<IToken> operationStack = new Stack<IToken>();

            operationStack.Push(new Operation("("));
            tokens.Add(new Operation(")"));

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                if (token is Operation)
                {
                    if (token.Content == "(")
                        operationStack.Push(token);
                    else if (token.Content == ")")
                    {
                        while (operationStack.Peek().Content != "(")
                        {
                            tokenList.Add(operationStack.Pop());
                        }

                        operationStack.Pop();
                    }
                    else
                    {
                        while  ((operationStack.Count > 0) && 
                            (GetPriority(token as Operation) <= GetPriority(operationStack.Peek() as Operation)))
                        {
                            if ((operationStack.Peek().Content == "("))
                                break;   
                            else
                                tokenList.Add(operationStack.Pop());
                        }

                        operationStack.Push(token);
                    }
                }
                else
                {
                    tokenList.Add(token);
                }
            }

            return tokenList;
        }

        public static string ToPrefixString(string expression)
        {
            var tokens = Tokenizer.Tokenize(expression);
            var list = GetPrefixList(tokens);

            var result = "";

            for (int i = 0; i < list.Count; i++)
            {
                result += list[i].Content + " ";
            }

            return result;
        }
    }
}
