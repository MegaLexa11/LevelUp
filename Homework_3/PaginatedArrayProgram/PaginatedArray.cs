using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PaginatedArrayProgram
{
    internal class PaginatedArray<T>(int arrSize, int pageSize) : IEnumerable<T>
    {
        private T[] _items = new T[arrSize];

        private int _pageSize = pageSize;
        
        public void addVal(T value, int place)
        {
            try
            {
                _items[place] = value;
            }
            // Хотя, по сути, выдаст ту же ошибку, даже если не обрабатывать
            catch 
            {
                throw new IndexOutOfRangeException();
            }
        }   

        public int Length => _items.Length;

        public T[] this[int index]
        {
            get
            {
                int startIndex = (index - 1) * _pageSize;
                int lastIndex = index * _pageSize;
                if (lastIndex <= _items.Length)
                {
                    T[] pageData = new T[_pageSize];
                    Array.ConstrainedCopy(_items, startIndex, pageData, 0, pageSize);
                    return pageData;
                }
                // Обработка неполной страницы
                else if (lastIndex - _pageSize < _items.Length)
                {
                    T[] pageData = new T[_items.Length - startIndex];
                    Array.ConstrainedCopy(_items, startIndex, pageData, 0, _items.Length - startIndex);
                    return pageData;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }

            }
            // По сути, не совсем корректно сеттер оставлять в обычном виде, поэтому вывел добавление значения в отдельный метод
            //set => _items[index] = value;
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
