using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    internal class ItemPrice
    {

        public int Price { get; set; }

        Dictionary<DateTime, int> PriceStory = new Dictionary<DateTime, int>();

        public string Currency { get; }

        public ItemPrice(int price, string currency) 
        {
            Price = price;
            Currency = currency;
        }

        public override string ToString() 
        {
            return $"{Price} {Currency}";
        }

        public void UpdatePrice(int newPrice)
        {
            PriceStory[DateTime.Now] = newPrice;
            Price = newPrice;
        }
    }
}
