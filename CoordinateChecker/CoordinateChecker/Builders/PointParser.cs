using System.Text.RegularExpressions;

namespace CoordinateChecker.Builders
{
    internal static class PointParser
    {
        public static string[] GetPointCoordinates()
        {
            string reCoordinateExpression = @"^\s*[-]?[0-9]+\s+[-]?[0-9]+\s+[-]?[0-9]+\s*$";
            Regex reSpaces = new(@"\s+");

            while (true)
            {
                Console.Write("Input coordinates of the point divided by space: ");
                string coordinatesString = Console.ReadLine() ?? string.Empty;

                if (Regex.IsMatch(coordinatesString, reCoordinateExpression))
                {
                    string finalCoordinatesString = reSpaces.Replace(coordinatesString.Trim(), " ");
                    string[] coordinatesArr = finalCoordinatesString.Split(" ");
                    return coordinatesArr;
                }
                Console.WriteLine("Incorrect input!");
            }
        }
    }
}
