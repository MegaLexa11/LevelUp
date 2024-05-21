using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableListProgram
{
    internal class ObservableListNotifier<T>
    {
        public delegate void NewItem(T item);

        public event NewItem? NewItemAddedEvent;

        public void ProcessNewItemAdded(T item)
        {

            NewItemAddedEvent?.Invoke(item);
        }
    }
}
