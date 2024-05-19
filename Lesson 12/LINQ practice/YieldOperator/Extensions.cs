namespace YieldOperator;

public static class Extensions
{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Predicate<T> filterFunc)
    {
        foreach (var item in source)
        {
            if (filterFunc(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<string> Loop(this WeekDays weekDays, string? untilDay = null)
    {
        yield return weekDays.Monday;
        yield return weekDays.Tuesday;
        yield return weekDays.Wednesday;
        yield return weekDays.Thursday;
        yield return weekDays.Friday;
        yield return weekDays.Saturday;
        yield return weekDays.Sunday;
    }
    
    public static IEnumerable<string> LoopUntil(this WeekDays weekDays, string? untilDay = null)
    {
        string[] days =
        [
            weekDays.Monday,
            weekDays.Tuesday,
            weekDays.Wednesday,
            weekDays.Thursday,
            weekDays.Friday,
            weekDays.Saturday,
            weekDays.Sunday,
        ];

        foreach (var day in days)
        {
            if (day == untilDay)
            {
                yield break;
            }

            yield return day;
        }
    }
}