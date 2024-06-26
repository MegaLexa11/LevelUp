﻿namespace Electronics
{
    internal abstract class ProductItem
    {
        public string Name { get; }
        public Guid Id { get; }
        public string Brand { get; }

        public abstract ElectronicsType Type { get; }

        protected ProductItem(string name, string brand) 
        { 
            Name = name;
            Brand = brand;
            Id = Guid.NewGuid();
        }

    }
}
