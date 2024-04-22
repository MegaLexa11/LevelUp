using System.Collections;

namespace DynamicArrayProgram
{
    internal class DynamicArray<T> : IEnumerable<T>
    {
        private T[] _items = new T[8];

        private int _lastIndex = 0;

        public void Add(T item)
        {
            int nextIndex = _lastIndex + 1;

            if (nextIndex == _items.Length)
            {
                T[] resizedArr = new T[_items.Length * 2];
                Array.Copy(_items, resizedArr, _items.Length);
                _items = resizedArr;
            }
            _items[_lastIndex] = item;
            _lastIndex = nextIndex;
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(_items, item, 0);
            if (index >= 0)
            {
                T[] resizedArr = new T[_items.Length];
                Array.Copy(_items, resizedArr, index);
                Array.ConstrainedCopy(_items, index + 1, resizedArr, index, _items.Length - index - 1);
                _lastIndex = _lastIndex - 1;
                _items = resizedArr;
            }
            else
            {
                throw new ArgumentException("There is no such an object in the dynamic array");
            }
        }

        public T this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public int Search(T item ) 
        {
            return Array.IndexOf(_items, item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}

