using System.Collections;

namespace IEnumerableInternals;

public sealed class RandomNumbersSetEnumerator(RandomNumbersSet set) : IEnumerator<int>
{
    private int _currentPosition = -1;

    public int Current => set.Numbers[_currentPosition];
    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        var hasNext = _currentPosition < set.Numbers.Length - 1;
        if (hasNext)
        {
            _currentPosition++;
        }

        return hasNext;
    }
    
    public void Reset()
    {
        _currentPosition = -1;
    }
    
    public void Dispose()
    {
        // ... Нет неуправляемых ресурсов, ничего не делаем
    }
}