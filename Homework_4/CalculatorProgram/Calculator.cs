using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProgram
{
    internal class Calculator
    {
        public static double Calculate(int num1, int num2, string action)
        {
            double result = action switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => Math.Round((double)num1 / (double)num2, 2),
                "^" => Math.Pow((double)num1, (double)num2),
                _ => throw new ArgumentException()
            };
            return result;
        }

        public static double Sin(int num) 
        {
            return Math.Sin(num);
        }

        public static double Cos(int num)
        {
            return Math.Cos(num);
        }
    }
}
