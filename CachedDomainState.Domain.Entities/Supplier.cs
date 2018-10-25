namespace CachedDomainState.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using CachedDomainState.Domain.Core;

    public class Supplier : IEntity
    {
        public Supplier(string name, string emailAddress)
        {
            this.Name = name;
            this.EmailAddress = emailAddress;
            this.Id = Guid.NewGuid();
        }

        public Supplier(string name, string emailAddress, IEnumerable<Product> productsSold) : this(name, emailAddress)
        {
            this.StockList = new HashSet<Product>(productsSold);
        }

        public string Name { get; private set; }
        public string EmailAddress { get; private set; }
        public Guid Id { get; private set; }
        public HashSet<Product> StockList { get; private set; } = new HashSet<Product>();

        public Order CreateOrder()
        {
            return new Order(this);
        }

        public void AddProductToStockList(Product product)
        {
            StockList.Add(product);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
