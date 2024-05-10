using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
