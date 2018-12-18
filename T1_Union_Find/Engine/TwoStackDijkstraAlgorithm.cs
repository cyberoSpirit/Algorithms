using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T1_Union_Find.Engine
{
    public class TwoStackDijkstraAlgorithm
    {
        public TwoStackDijkstraAlgorithm()
        {
        }

        public static int CalculateExp(string expression)
        {
            Stack<int> values = new Stack<int>();
            Stack<string> operations = new Stack<string>();

            Regex numberRex = new Regex(@"[\d]");
            Regex operation = new Regex(@"[+-/*]");

            for (int i = 0; i < expression.Length; ++i)
            {
                if(expression[i] == ')')
                {
                    values.Push(
                        MakeOperation(values.Pop(), values.Pop(), operations.Pop()));
                }
                else if (numberRex.IsMatch(expression[i].ToString()))
                {
                    values.Push(Convert.ToInt32(expression[i].ToString()));
                }
                else if (operation.IsMatch(expression[i].ToString()))
                {
                    operations.Push(expression[i].ToString());
                }
            }
            return values.Pop();
        }

        private static int MakeOperation(int a, int b, string operation)
        {
            switch(operation)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "/":
                    return a / b;
                case "*":
                    return a * b;
                default:
                    return 0;
            }
        }
    }
}
