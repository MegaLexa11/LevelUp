namespace CoordinateChecker
{
    internal struct AxisPoint
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public AxisPoint(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"{X} {Y} {Z}";
        }
    }
}
