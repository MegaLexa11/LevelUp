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
        //int[] someArr = new int[]{1, 2, 3, 4, 5, 6, 7, 8};
        
        // Переделать заполнение массива и получение страницы - поменять местами, добавить обработку неполной страницы
        public T[] getPageData(int pageNumber)
        {
            int startIndex = (pageNumber - 1) * _pageSize;
            int lastIndex = pageNumber * _pageSize;
            if (lastIndex <= _items.Length)
            {
                T[] pageData = new T[_pageSize];
                Array.ConstrainedCopy(_items, startIndex, pageData, 0, pageSize);
                return pageData;
            }
            // Обработка неполной страницы
            /*else if (lastIndex - _pageSize < _items.Length)
            {
                T[] pageData = new T[_pageSize];
                Array.ConstrainedCopy(_items, startIndex, pageData, 0, pageSize);
                return pageData;
            }*/
            else
            {
                throw new ArgumentException("Index out of range");
            }
            
        }

        public int Size()
        {
            return _items.Length;
        }

        public T this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
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
