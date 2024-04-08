

namespace Homework_1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            bool isNum1 = int.TryParse(Console.ReadLine() ?? string.Empty, out int num1);

            Console.Write("Enter second number: ");
            bool isNum2 = int.TryParse(Console.ReadLine() ?? string.Empty, out int num2);
            if (isNum1 && isNum2)
            {
                int result = num1 + num2;
                Console.WriteLine($"{num1} + {num2} = {result}");
            }
            else
            {
                Console.WriteLine("You should use only numbers!");
            }
        }
    }
}
