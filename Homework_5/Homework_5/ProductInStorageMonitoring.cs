using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    // Его бы как синглтон, и чтобы содержал dictionary
    internal class ProductInStorageMonitoring 
    {

        private static List<ProductInStorage> ItemStorageList;

        private static ProductInStorageMonitoring instance;

        private ProductInStorageMonitoring()
        {
            ItemStorageList = new List<ProductInStorage>(100);
        }

        public static ProductInStorageMonitoring AddProductToStorage(ProductItem item, Storage storageToCheck, int? amount = null)
        {
            if (instance == null)
            {
                instance = new ProductInStorageMonitoring();
            }

            // Вероятно, лишнее - сюда это добавлять, и нужен отдельный метод
            bool itemExists = ItemStorageList.Any(i => i.Item == item && i.ItemStorage == storageToCheck);

            amount = amount ?? 1;

            if (itemExists)
            {
                ProductInStorage itemToUpdate = ItemStorageList.Find(i => i.Item == item && i.ItemStorage == storageToCheck);
                itemToUpdate.Amount += (int)amount;
            } 
            else
            {
                ItemStorageList.Add(new ProductInStorage(item, storageToCheck, (int)amount));
            }
                
            return instance;
        }

        public static void PrintProducts()
        {
            foreach (ProductInStorage item in ItemStorageList)
            {
                Console.WriteLine(item);
            }
        }

        // Шото с чем то, но пускай будет
        /*public ProductInStorage(ProductItem item, Storage itemStorage, int amount)
        {
            Item = item;
            ItemStorage = itemStorage;
            Amount = amount;

            // Опять же проверить, как ведет себя штука
            var existingItems = (List<ProductInStorage>)(from i in ItemStorageList where i.ItemStorage == itemStorage && i.Item == item select i);
            bool itemExists = existingItems.Count() > 0;
            //bool itemExists = ItemStorageList.Any(i => i.Item == item && i.ItemStorage == itemStorage);
            if (itemExists) 
            {
                var existingItem = existingItems[0];
                existingItem.Amount += amount;
                // Тут бы еще как-то удалять экземпляр, который просто количество добавил
            } 
            else
            {
                ItemStorageList.Add(this);
            }
            
        }*/

    }
}
