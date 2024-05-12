using homework_7;

Console.WriteLine("Приветствуем в программе по расчету площади фигур!");
Console.WriteLine("Доступные для выбора фигуры:");
Console.WriteLine("1. Прямоугольник");
Console.WriteLine("2. Круг");
Console.Write("Введите номер фигуры, площадь которой хотите рассчитать: ");
var figureNum = Console.ReadLine();
// Ранее тут было лишнее повторение кода, так как в свитч кейсе обрабатывался неверный ввод, из-за которого, по сути, программа не отрабатывала, и было бы нелогично потом вызывать расчет площади и т.п.
// Поэтому вначале пусть ввод фигуры обрабатывается так:
while (figureNum != "1" && figureNum != "2")
{
    Console.WriteLine("Неверный ввод!");
    figureNum = Console.ReadLine();
}

// Конечно, создается лишний билдер, если вдруг результат 2...
IFigureBuilder figureBuilder = new RectangleBuilder(new RectangleParser());
switch (figureNum)
{
    case "1":
        break;
    case "2":
        figureBuilder = new CircleBuilder(new CircleParser());
        break;
}

IFigure figure = figureBuilder.Build();
double square = figure.EvaluateSquare();
Console.WriteLine($"Площадь фигуры: {square}");