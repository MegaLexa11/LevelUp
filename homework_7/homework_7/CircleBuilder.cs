namespace homework_7
{
    internal class CircleBuilder : IFigureBuilder
    {
        public IInputParser InputParser { get; }

        public CircleBuilder(IInputParser inputParser)
        {
            InputParser = inputParser;
        }
        public IFigure Build()
        {
            var parameters = InputParser.Parse();
            if (parameters.Length != 1)
            {
                throw new ArgumentException("Неверное количество параметров!");
            }
            if (double.TryParse(parameters[0], out var radius))
            {
                return new Circle(radius);
            } 
            else
            {
                throw new ArgumentException("Неверное значение радиуса!");
            }
        }
    }
}
