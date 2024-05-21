using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableListProgram
{
    internal class ObservableList<T>
    {
        public List<T> list;

        public void Add(T item, ObservableListNotifier<T> notifier)
        {
            list.Add(item);
            notifier.NewItemAddedEvent += PrintNewItemEvent;
        }

        public void Remove(T item)
        {
            list.Remove(item);
        }

        public int Count()
        {
            return list.Count;
        }

        public ObservableList() 
        {
            list = new List<T>();
        }

        private void PrintNewItemEvent(T item)
        {
            Console.WriteLine($"Added new Item - {item}");
        }
    }
}
