using YieldOperator;
PlayWithYieldReturn();
// PlayWithYieldBreak();

void PlayWithYieldReturn()
{
    var digits = "0123456789";
    var testString = "I've learn LINQ 100500 times, but got it only in 100501";

    var filteredChars = testString.Filter(ch => digits.Contains(ch));
    Console.WriteLine(new string(filteredChars.ToArray()));

    int[] numbers = [15, 24, 32, 45, 97];
    var filteredNumbers = numbers.Filter(number => number < 50);
    foreach (var number in filteredNumbers)
    {
        Console.Write($"{number} ");
    }

    Console.WriteLine();
    
    var weekDays = new WeekDays();
    foreach (var day in weekDays.Loop())
    {
        Console.WriteLine(day);
    }
}

void PlayWithYieldBreak()
{
    var weekDays = new WeekDays();
    foreach (var day in weekDays.LoopUntil(weekDays.Friday))
    {
        Console.WriteLine(day);
    }
}