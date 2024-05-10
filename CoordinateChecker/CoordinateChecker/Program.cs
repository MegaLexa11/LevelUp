// Дисклеймер: попытался сделать так, чтобы вместо ошибок при взаимодействии с пользователем программа выдавала возможность продолжить работу, поэтому много чего зациклено

using CoordinateChecker;
using CoordinateChecker.Builders;
using CoordinateChecker.Extensions;

/*var point1 = new AxisPoint(1, 2, 3);
var point2 = new AxisPoint(1, 2, 3);

AxisPoint[] points = [point1];

Console.WriteLine(points.Contains(point2));

int[] arr = [1, 2, 2, 4, 5, 1, 2, 7, 8, 9];
int el = arr.RarestEl();

Console.WriteLine(el);*/

/*UserCommunicator.GreetUser();
AxisSquare square = SquareBuilder.Build();

foreach (AxisPoint point in square.PointsCoordinates)
{
    Console.WriteLine($"{point.X} {point.Y} {point.Z}");
}*/

string string1 = "XYZ";
string string2 = "XZ";

string noIncluded = string2.AllNotIncluded(string1);
Console.WriteLine(noIncluded);
Console.WriteLine(noIncluded.Length);