namespace CoordinateChecker
{
    internal class AxisCube 
    {
        // По-хорошему, нужно, чтобы плоскости были закономерно расположены во всех экземплярах объекта, а то так сложнее работать
        public AxisSquare AxisSquare1 { get; }
        public AxisSquare AxisSquare2 { get; }

        public string SquaresPerpendicularTo { get; }

        public AxisCube(AxisSquare axisPlane1, AxisSquare axisPlane2, string squaresPerpendicularTo)
        {
            AxisSquare1 = axisPlane1;
            AxisSquare2 = axisPlane2;
            SquaresPerpendicularTo = squaresPerpendicularTo; 
        }

        public override string ToString()
        {
            return $"{AxisSquare1}|{AxisSquare2}";
        }
    }
}
