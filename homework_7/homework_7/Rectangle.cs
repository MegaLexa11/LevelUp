namespace homework_7
{
    internal class Rectangle(double width, double height) : IFigure
    {
        public double Width { get; } = width;
        public double Height { get; } = height;

        public double EvaluateSquare()
        {
            return Width * Height;
        }
    }
}
