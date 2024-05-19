using System.Collections;

namespace IEnumerableInternals;

public sealed class RandomNumbersSet : IEnumerable<int>
{
    private readonly int _fromValue;
    private readonly int _toValue;
    
    public int[] Numbers { get; }

    public RandomNumbersSet(int numbersCount, int fromValue = 0, int toValue = 100)
    {
        _fromValue = fromValue;
        _toValue = toValue;
        Numbers = new int[numbersCount];
        Reset();
    }
    
    public void Reset()
    {
        var rnd = new Random();
        for (var i = 0; i < Numbers.Length; i++)
        {
            Numbers[i] = rnd.Next(_fromValue, _toValue);
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new RandomNumbersSetEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}