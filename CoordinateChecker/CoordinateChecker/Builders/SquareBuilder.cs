using CoordinateChecker.Extensions;

namespace CoordinateChecker.Builders
{
    internal static class SquareBuilder
    {
        public static AxisSquare Build()
        {
            int pointsToMakeSquare = 4;
            AxisPoint[] SquarePoints = new AxisPoint[pointsToMakeSquare];
            double edgeLength;
            AxisPoint point1, point2, point3;

            //Нужно больше подсказок

            // Пробовал сделать через цикл, но в каждой из 3 точек свои нюансы - в принципе, если бы для куба запрашивал все точки, то точно был бы цикл
            // Точка 1
            Console.WriteLine("Point 1:");
            string[] coordinatesString = PointParser.GetPointCoordinates();
            point1 = PointBuilder.Build(coordinatesString);
            SquarePoints[0] = point1;
            UserCommunicator.PointCommited();


            // Точка 2
            Console.WriteLine("Point 2:");
            while (true)
            {
                coordinatesString = PointParser.GetPointCoordinates();
                point2 = PointBuilder.Build(coordinatesString);
                if (Coordinates.IsLineParallel(point2, point1) && !SquarePoints.Contains(point2))
                {
                    SquarePoints[1] = point2;
                    edgeLength = Coordinates.DistanceBetweenPoints(point2, point1);
                    break;
                }
                Console.WriteLine("The line, made of 2 points is not parallel to any of axes!");
            }
            UserCommunicator.PointCommited();

            // Точка 3
            Console.WriteLine("Point 3:");
            while (true)
            {
                coordinatesString = PointParser.GetPointCoordinates();
                point3 = PointBuilder.Build(coordinatesString);
                double newEdgeLength = Coordinates.DistanceBetweenPoints(point3, point2);
                if (Coordinates.IsLineParallel(point3, point2) && !SquarePoints.Contains(point3) && newEdgeLength == edgeLength)
                {
                    SquarePoints[2] = point3;
                    break;
                }
            }
            UserCommunicator.PointCommited();

            // Точка 4 достраивается автоматически, так как квадрат
            double[] XPoints = [point1.X, point2.X, point3.X];
            double[] YPoints = [point1.Y, point2.Y, point3.Y];
            double[] ZPoints = [point1.Z, point2.Z, point3.Z];

            double x = XPoints.RarestEl();
            double y = YPoints.RarestEl();
            double z = ZPoints.RarestEl();

            AxisPoint point4 = new AxisPoint(x, y, z);

            return new AxisSquare(point1, point2, point3, point4);
        }

    }
}
