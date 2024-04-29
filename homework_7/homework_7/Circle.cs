namespace homework_7
{
    internal class Circle : IFigure
    {
        double Radius { get; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double EvaluateSquare()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
