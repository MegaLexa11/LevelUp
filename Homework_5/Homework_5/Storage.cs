using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    // Сущность склада
    internal class Storage
    {
        public Guid Id;

        public string Name { get; set; }

        public int StorageNumber { get; }

        public string Location { get; }

        public Stock Stock { get; }

        // Остатки теперь тут
        internal Dictionary<Guid, int> ProductRest { get; } = new Dictionary<Guid, int>();

        public Storage(string name, int storageNumber, string location, Stock stock)
        {
            Id = Guid.NewGuid();
            Name = name;
            StorageNumber = storageNumber;
            Location = location;
            Stock = stock;
        }

        public void AddItem(ProductItem item, int? amount = null)
        {
            amount = amount ?? 1;
            if (ProductRest.ContainsKey(item.Id))
            {
                ProductRest[item.Id] += (int)amount;
            }
            else
            {
                ProductRest[item.Id] = (int)amount;
            }
        }

        // Метод вывода товаров на складе

        public void PrintProducts()
        {
            foreach (var item in ProductRest)
            {
                Console.WriteLine($"{Stock.GetItemById(item.Key).Name}: {item.Value}");
            }
        }
        
    }
}
