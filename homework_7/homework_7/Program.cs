using homework_7;

Console.WriteLine("Приветствуем в программе по расчету площади фигур!");
Console.WriteLine("Доступные для выбора фигуры:");
Console.WriteLine("1. Прямоугольник");
Console.WriteLine("2. Круг");
Console.Write("Введите номер фигуры, площадь которой хотите рассчитать: ");
var figureNum = Console.ReadLine();
IFigure figure;
double square;
switch (figureNum)
{
    case "1":
        RectangleBuilder rectangleBuilder = new RectangleBuilder(new RectangleParser());
        figure = rectangleBuilder.Build();
        square = figure.EvaluateSquare();
        Console.WriteLine($"Площадь фигуры: {square}");
        break;
    case "2":
        CircleBuilder circleBuilder = new CircleBuilder(new CircleParser());
        figure = circleBuilder.Build();
        square = figure.EvaluateSquare();
        Console.WriteLine($"Площадь фигуры: {square}");
        break;
    default:
        Console.WriteLine("Неверный ввод!");
        break;
}