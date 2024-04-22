using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    internal class Invoice
    {

        public Dictionary<ProductItem, int> ProductItems = new Dictionary<ProductItem, int>();

        public Storage StorageDestination { get; }

        public Invoice(Storage storageDestination)
        {
            //ProductItems = ProductItems;
            StorageDestination = storageDestination;
        }

        public void AddItem(ProductItem item, int amount)
        {
            if (ProductItems.ContainsKey(item)) 
            {
                ProductItems[item] += amount;
            }
            else
            {
                ProductItems[item] = amount;
            }    
        }

        // Метод отгрузить - с созданием ProductInStorage, вызовом конструктора товара
    }
}
