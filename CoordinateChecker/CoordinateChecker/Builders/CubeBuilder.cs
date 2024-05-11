namespace CoordinateChecker.Builders
{
    internal static class CubeBuilder
    {
        // Вообще, запрашивать все 8 координат - долго, муторно, проверять скучно, да и, в целом, трудозатратно, плюс, пользователь сам забудет, что он там вводил, поэтому строим плоскость из 3 точек, растим ее по одному из двух направлений, и все
        public static AxisCube Build()
        {
            Console.WriteLine("Cube coordinates.");
            AxisSquare square1 = SquareBuilder.Build();
            double edgeLength = Coordinates.DistanceBetweenPoints(square1.PointsCoordinates[0], square1.PointsCoordinates[1]);
            (string directionStr, bool directionBool) growPair = DirectionToGrow(square1);
            string GrowDirection = growPair.directionStr;
            bool isDirectionUp = growPair.directionBool;
            if (!isDirectionUp) { edgeLength = -edgeLength; }

            double addX = 0;
            double addY = 0;
            double addZ = 0;

            if (GrowDirection == "X")
            {
                addX = edgeLength;
            }
            else if (GrowDirection == "Y")
            {
                addY = edgeLength;
            }
            else
            {
                addZ = edgeLength;
            }


            AxisPoint[] NewSquareCoordinates = new AxisPoint[4];
            for (int i = 0; i < square1.PointsCoordinates.Length; i++)
            {
                AxisPoint point = square1.PointsCoordinates[i];
                AxisPoint newPoint = new AxisPoint(point.X + addX, point.Y + addY, point.Z + addZ);
                NewSquareCoordinates[i] = newPoint;
            }
            AxisSquare square2 = new AxisSquare(NewSquareCoordinates[0], NewSquareCoordinates[1], NewSquareCoordinates[2], NewSquareCoordinates[3]);

            return new AxisCube(square1, square2, square1.PerpendicularTo());
        }


        // 
        private static (string, bool) DirectionToGrow(AxisSquare square)
        {
            //string baseAxes = "XYZ";
            string AxisToGrow = square.PerpendicularTo();

            while (true)
            {
                Console.Write($"The cube will grow along the {AxisToGrow} axis. Which direction would you like it to grow? (up/down): ");
                string direction = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
                if (direction != "up" && direction != "down")
                {
                    Console.WriteLine("Incorrect direction!");
                    continue;
                }
                bool isDirectionUp = String.Compare(direction, "up") == 0;
                Console.WriteLine("Direction was chosen!");
                return (AxisToGrow, isDirectionUp);
            }
            
        }
    }
}
