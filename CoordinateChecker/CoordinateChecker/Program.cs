// Дисклеймер: попытался сделать так, чтобы вместо ошибок при взаимодействии с пользователем программа выдавала возможность продолжить работу, поэтому много чего зациклено

using CoordinateChecker;
using CoordinateChecker.Builders;


UserCommunicator.GreetUser();
Console.WriteLine();

AxisCube cube = CubeBuilder.Build();
Console.WriteLine("Coordinates of the cube tops:");
Console.WriteLine(cube);
Console.WriteLine();

Console.WriteLine("Now you will input coordinates of the point to know if it belongs to the cube.");
string[] pointCoordinates = PointParser.GetPointCoordinates();
AxisPoint point = PointBuilder.Build(pointCoordinates);

if(Coordinates.IsPointInCube(point, cube))
{
    Console.WriteLine($"Point {point} belongs to cube!");
}
else
{
    Console.WriteLine($"Point {point} doesn't belong to cube.");
     
}