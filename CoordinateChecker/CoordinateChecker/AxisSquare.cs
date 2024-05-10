﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateChecker
{

    // Может, сделать AxisSquare???
    internal class AxisSquare

    {
        // Минимум точек для построения плоскости - 3, но в ней, явно, может лежать и больше
        public AxisPoint[] PointsCoordinates { get; }

        // Не массив, так как важно, что передаются именно 3 точки
        public AxisSquare(AxisPoint point1, AxisPoint point2, AxisPoint point3, AxisPoint point4)
        {
            PointsCoordinates = [point1, point2, point3, point4];
        }

        // Предполагается, что в массиве нет одинаковых точек
        public string ParallelTo()
        {
            char[] parallelTo = new char[2];
            int lastCharIndex = 0;

            AxisPoint point1 = PointsCoordinates[0];
            AxisPoint point2 = PointsCoordinates[1];
            AxisPoint point3 = PointsCoordinates[2];

            if (point1.X == point2.X && point1.X == point3.X) {
                parallelTo[lastCharIndex++] = 'X';
            }

            if (point1.Y == point2.Y && point1.Y == point3.Y)
            {
                parallelTo[lastCharIndex++] = 'Y';
            }

            if (point1.Z == point2.Z && point1.Z == point3.Z)
            {
                parallelTo[lastCharIndex++] = 'Z';
            }

            return new string(parallelTo);
        }
    }
}
