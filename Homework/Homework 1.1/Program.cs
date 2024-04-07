namespace Homework_1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine() ?? string.Empty);
            int result = num1 + num2;

            Console.WriteLine($"{num1} + {num2} = {result}");

        }
    }
}
