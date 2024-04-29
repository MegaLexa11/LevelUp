namespace homework_7
{
    internal class CircleParser : IInputParser
    {
        public string[] Parse()
        {
            string[] radius = new string[1];
            Console.Write("Введите радиус: ");
            radius[0] = Console.ReadLine() ?? string.Empty;
            return radius;
        }
    }
}
