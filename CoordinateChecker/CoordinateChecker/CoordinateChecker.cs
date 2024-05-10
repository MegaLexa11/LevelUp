using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateChecker
{
    internal static class CoordinateChecker
    {
       
        public static bool IsDotInCube(AxisPoint dot, AxisCube cube)
        {
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
