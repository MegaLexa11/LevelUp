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
        public List<ProductItem> Items { get; }
        
        public Stock(int baseSize)
        {
            Items = new List<ProductItem>(baseSize);
        }

        // Проверить
        public void AddToStock(ProductItem item)
        {
            if (!Items.Contains(item))
            {
                Items.Add(item);
            }
        }

        public ProductItem this[int index]
        {
            get => Items[index];
        }

        public void StoreItems(Invoice invoice)
        {
            Dictionary<ProductItem, int> items = invoice.ProductItems;
            Storage storage = invoice.StorageDestination;
            foreach (var item in items) 
            {
                AddToStock(item.Key);
                ProductInStorageMonitoring.AddProductToStorage(item.Key, storage, item.Value);
            }
        }
        // Какой-нибудь вывод общего числа товаров на складах, без привязки к складу или с привязкой - в принципе, пофиг
    }
}
