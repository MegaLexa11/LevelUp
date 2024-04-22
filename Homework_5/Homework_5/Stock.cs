using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    // Сущность ассортимента
    internal class Stock
    {
        // Подумать еще над этой штукой
        public List<ProductItem> Items { get; } = new List<ProductItem>();

        // Проверить
        public void AddToStock(ProductItem item)
        {
            bool ItemExistis = Items.Any(i => i.Id == item.Id); 
            if (!ItemExistis)
            {
                Items.Add(item);
            }
        }

        public void StoreItems(Invoice invoice)
        {
            Dictionary<ProductItem, int> items = invoice.ProductItems;
            Storage storage = invoice.StorageDestination;
            foreach (var item in items) 
            {
                AddToStock(item.Key);
                storage.addItem(item.Key, item.Value);
            }
        }

        internal ProductItem GetItemById(Guid id)
        {
            ProductItem item = Items.Find(i => i.Id == id);
            return item;
        }
    }
}
