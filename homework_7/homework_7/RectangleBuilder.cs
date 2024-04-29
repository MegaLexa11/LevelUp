namespace homework_7
{
    internal class RectangleBuilder : IFigureBuilder
    {
        public IInputParser InputParser { get; }

        public RectangleBuilder(IInputParser inputParser)
        {
            InputParser = inputParser;
        }

        public IFigure Build()
        {
            var parameters = InputParser.Parse();
            if (parameters.Length != 2) 
            {
                throw new ArgumentException("Неверное количество параметров!");
            }
            if (double.TryParse(parameters[0], out double Height) && double.TryParse(parameters[1], out double Width))
            {
                return new Rectangle(Height, Width);
            }
            else
            {
                throw new ArgumentException("Неверное значение длины или ширины!");
            }
        }
    }
}
