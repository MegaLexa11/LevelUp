using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoordinateChecker.Extensions;

namespace CoordinateChecker.Builders
{
    internal static class SquareBuilder
    {
        public static AxisSquare Build()
        {
            int pointsToMakeSquare = 4;
            AxisPoint[] PlanePoints = new AxisPoint[pointsToMakeSquare];
            double edgeLength;
            AxisPoint point1, point2, point3;

            //Нужно больше подсказок

            // Пробовал сделать через цикл, но в каждой из 3 точек свои нюансы - в принципе, если бы для куба запрашивал все точки, то точно был бы цикл
            // Точка 1
            string[] coordinatesString = PointParser.GetPointCoordinates();
            point1 = PointBuilder.Build(coordinatesString);
            PlanePoints[0] = point1;
            UserCommunicator.PointCommited();


            // Точка 2
            while (true)
            {
                coordinatesString = PointParser.GetPointCoordinates();
                point2 = PointBuilder.Build(coordinatesString);
                if (CoordinateChecker.IsLineParallel(point2, point1) && !PlanePoints.Contains(point2))
                {
                    PlanePoints[1] = point2;
                    edgeLength = CoordinateChecker.DistanceBetweenPoints(point2, point1);
                    break;
                }
                Console.WriteLine("The line, made of 2 points is not parallel to any of axes!");
            }
            UserCommunicator.PointCommited();

            // Точка 3
            while (true)
            {
                coordinatesString = PointParser.GetPointCoordinates();
                point3 = PointBuilder.Build(coordinatesString);
                double newEdgeLength = CoordinateChecker.DistanceBetweenPoints(point3, point2);
                if (CoordinateChecker.IsLineParallel(point3, point2) && !PlanePoints.Contains(point3) && newEdgeLength == edgeLength)
                {
                    PlanePoints[2] = point3;
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
