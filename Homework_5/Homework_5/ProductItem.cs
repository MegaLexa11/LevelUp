using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    // Сущность товара
    internal class ProductItem
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Measure { get; }

        public ItemPrice Price { get; }

        public ProductItem(string name, string? description, string measure, int price, string currency)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Measure = measure;
            Price = new ItemPrice(price, currency);
        }

    }
}
