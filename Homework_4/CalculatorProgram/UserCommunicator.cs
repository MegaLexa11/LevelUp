using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProgram
{
    internal class UserCommunicator
    {
        public static void CalculatorGreeting()
        {
            Console.WriteLine("Welcome to simple expression calculator!");
            Console.WriteLine("Available actions:");
            Console.WriteLine("- Addiction (+);");
            Console.WriteLine("- Subtraction (-);");
            Console.WriteLine("- Multiplication (*);");
            Console.WriteLine("- Division (+);");
            Console.WriteLine("- Exponentiation (^);");
            Console.WriteLine("- Cosinus();");
            Console.WriteLine("- Sinus().");
            Console.WriteLine("Expression example: 1+2 or cos(30)");
            Console.WriteLine();
        }

        public static void CalculatorFinishing(double result) 
        {
            Console.WriteLine($"The result is {result}");
        }

        public static bool CalculatorContinuing()
        {
            Console.Write("Would you like to calculate again (y)?: ");
            string oneMoreCalc = (Console.ReadLine() ?? string.Empty).ToLower();
            bool IsOneMoreCalc = String.Compare(oneMoreCalc, "y") == 0;
            return IsOneMoreCalc;
        }
    }
}
