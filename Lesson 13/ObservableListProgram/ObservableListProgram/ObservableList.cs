namespace ObservableListProgram
{
    internal class ObservableList<T>
    {
        public List<T> list;

        public delegate void NewItem(string itemActionText);

        public event NewItem? NewItemAddedEvent;

        public void Add(T item)
        {
            list.Add(item);
            NewItemAddedEvent?.Invoke($"Added new item - {item}");
        }

        public bool Remove(T item)
        {
            bool isRemoved = list.Remove(item);
            if (isRemoved) 
            {
                NewItemAddedEvent?.Invoke($"Removed item - {item}");
            } 
            else
            {
                NewItemAddedEvent?.Invoke($"There is no item {item} in list");
            }
            
            return isRemoved;
        }

        public int Count()
        {
            return list.Count;
        }

        public ObservableList() 
        {
            list = new List<T>();
            NewItemAddedEvent += PrintItemAction;
        }

        private void PrintItemAction(string actionText)
        {
            Console.WriteLine(actionText);
        }
    }
}
