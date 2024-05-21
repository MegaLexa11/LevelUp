namespace homework_7
{
    internal class RectangleParser : IInputParser
    {
        public string[] Parse()
        {
            string[] sides = new string[2];
            Console.Write("Введите длину: ");
            sides[0] = Console.ReadLine() ?? string.Empty;
            Console.Write("Введите ширину: ");
            sides[1] = Console.ReadLine() ?? string.Empty;
            return sides;
        }
    }
}
