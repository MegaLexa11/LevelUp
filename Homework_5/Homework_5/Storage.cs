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
        private Guid Id;
        public string Name { get; set; }

        public int StorageNumber { get; }

        public string Location { get; }
        
        public Storage(string name, int storageNumber, string location)
        {
            Id = Guid.NewGuid();
            Name = name;
            StorageNumber = storageNumber;
            Location = location;
        }

        // Метод вывода товаров на складе
    }
}
