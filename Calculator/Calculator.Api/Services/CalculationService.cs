using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Api.Models.Requests;
using Calculator.Api.Models.Responses;
using Calculator.Api.Services.Abstracts;

namespace Calculator.Api.Services
{
    public class CalculationService : ICalculationService
    {
        public async Task<CalculateResponse> Calculate(CalculateRequest request)
        {
            var postfix = ToPostfix(request.Expression);
            var rpn = CalculateRPN(postfix);

            var result = new CalculateResponse
            {
                Result = (double)rpn
            };

            return await Task.FromResult(result);
        }

        private static readonly Dictionary<string, (string symbol, int precedence)> operators
            = new (string symbol, int precedence)[] {
                    ("*", 2),
                    ("/", 2),
                    ("+", 1),
                    ("-", 1)
        }.ToDictionary(op => op.symbol);

        private string ToPostfix(string infix)
        {
            string[] tokens = infix.Split(' ');
            var stack = new Stack<string>();
            var output = new List<string>();
            foreach (string token in tokens)
            {
                if (int.TryParse(token, out _))
                {
                    output.Add(token);
                }
                else if (operators.TryGetValue(token, out var op1))
                {
                    while (stack.Count > 0 && operators.TryGetValue(stack.Peek(), out var op2))
                    {
                        int c = op1.precedence.CompareTo(op2.precedence);
                        if (c < 0)
                        {
                            output.Add(stack.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }
                    stack.Push(token);
                }
            }
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                output.Add(top);
            }
            return string.Join(" ", output);
        }

        private static decimal CalculateRPN(string rpn)
        {
            string[] rpnTokens = rpn.Split(' ');
            var stack = new Stack<decimal>();
            decimal number = decimal.Zero;

            foreach (string token in rpnTokens)
            {
                if (decimal.TryParse(token, out number))
                {
                    stack.Push(number);
                }
                else
                {
                    switch (token)
                    {
                        case "*":
                            {
                                stack.Push(stack.Pop() * stack.Pop());
                                break;
                            }
                        case "/":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() / number);
                                break;
                            }
                        case "+":
                            {
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            }
                        case "-":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() - number);
                                break;
                            }
                    }
                }
            }

            return stack.Pop();
        }
    }
}