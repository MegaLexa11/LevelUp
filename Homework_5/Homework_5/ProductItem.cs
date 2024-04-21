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
        private Guid Id;

        public string Name { get; set; }

        public string? Description { get; set; }

        public string Measure { get; }

        public ProductItem(string name, string? description, string measure)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Measure = measure;
        }

    }
}
