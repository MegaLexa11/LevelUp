using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_5
{
    internal class ProductInStorage
    {
        public ProductItem Item;
        public Storage ItemStorage;
        public int Amount;

        public ProductInStorage(ProductItem item, Storage itemStorage, int amount)
        {
            Item = item;
            ItemStorage = itemStorage;
            Amount = amount;

        }
        public override string ToString()
        {
            return $"ItemName: {Item.Name}; Storage: {ItemStorage.Name}; Amount: {Amount}";
        }
    }
}
