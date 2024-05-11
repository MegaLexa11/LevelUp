namespace CoordinateChecker
{
    internal static class Coordinates
    {
       
        public static bool IsPointInCube(AxisPoint point, AxisCube cube)
        {
            // Как будто, в итоге, бессмыссленно, что храню координаты точек в отдельных квадратах в рамках куба, но так удобнее создавать куб - хотя можно все переделать, но создание объектов плоскостей станет бессмыссленным, а там хранятся нужные методы
            AxisPoint[] cubePoints = (cube.AxisSquare1.PointsCoordinates.Concat(cube.AxisSquare2.PointsCoordinates)).ToArray<AxisPoint>();
            double Xmax = cubePoints[0].X;
            double Xmin = cubePoints[0].X;
            double Ymax = cubePoints[0].Y;
            double Ymin = cubePoints[0].Y;
            double Zmax = cubePoints[0].Z;
            double Zmin = cubePoints[0].Z;

            foreach (AxisPoint p in cubePoints)
            {
                if(p.X > Xmax) { Xmax = p.X; }
                if(p.X < Xmin) { Xmin = p.X; }
                if(p.Y > Ymax) { Ymax = p.Y; }
                if(p.Y < Ymin) { Ymin = p.Y; }
                if(p.Z > Zmax) { Zmax = p.Z; }
                if(p.Z < Zmin) { Zmin = p.Z; }
            }

            if (point.X > Xmax || point.X < Xmin) { return false; }
            if (point.Y > Ymax || point.Y < Ymin) { return false; }
            if (point.Z > Zmax || point.Z < Zmin) { return false; }

            return true;
        }

        public static double DistanceBetweenPoints(AxisPoint point1, AxisPoint point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) + Math.Pow(point1.Z - point2.Z, 2));
        }

        public static bool IsLineParallel(AxisPoint point1, AxisPoint point2)
        {
            bool[] matches = [point1.X == point2.X, point1.Y == point2.Y, point1.Z ==point2.Z];
            int matchesCount = matches.Count(x => x);
            return matchesCount == 2;
        }
    }
}
