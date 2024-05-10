using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateChecker.Builders
{
    internal static class PointBuilder
    {
        public static AxisPoint Build(string[] coordinates)
        {
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);
            int z = int.Parse(coordinates[2]);
            return new AxisPoint(x, y, z);
        }
    }
}
