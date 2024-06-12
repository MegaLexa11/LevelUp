namespace ObservableListProgram
{
    internal class ObservableList<T>
    {
        public List<T> list;

        public delegate void ActionItem(string itemActionText);

        public event ActionItem? ActionItemEvent;

        public void Add(T item)
        {
            list.Add(item);
            ActionItemEvent?.Invoke($"Added new item - {item}");
        }

        public bool Remove(T item)
        {
            bool isRemoved = list.Remove(item);
            if (isRemoved) 
            {
                ActionItemEvent?.Invoke($"Removed item - {item}");
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
            ActionItemEvent += PrintItemAction;
        }

        private void PrintItemAction(string actionText)
        {
            Console.WriteLine(actionText);
        }
    }
}
