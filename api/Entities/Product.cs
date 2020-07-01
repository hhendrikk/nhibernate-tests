using System;

namespace api.Entities
{
    public class Product : Entity
    {
        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual decimal UnitPrice { get; protected set; }

        protected Product() { }

        public Product(string name, string description, decimal unitPrice)
            : this()
        {
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
        }
    }
}