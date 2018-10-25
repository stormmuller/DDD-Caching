namespace CachedDomainState.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using CachedDomainState.Domain.Core;
    using CachedDomainState.Domain.Exceptions.OrderExceptions;

    public class Order : Entity
    {
        public Order(Guid id, Supplier supplier) : base(id)
        {
            this.Supplier = supplier;
        }

        public Order(Supplier supplier) : this(Guid.NewGuid(), supplier) { }

        public Order(Supplier supplier, Dictionary<Product, int> products) : this(supplier)
        {
            this.Products = products;
        }

        public Supplier Supplier { get; private set; }
        public Dictionary<Product, int> Products { get; private set; }

        public void AddProduct(Product product, int quantity)
        {
            if (!Supplier.StockList.Contains(product))
            {
                throw new ProductUnavailableException(product);
            }

            if (Products.ContainsKey(product))
            {
                Products[product] += quantity;
            }
            else
            {
                Products.Add(product, quantity);
            }
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
