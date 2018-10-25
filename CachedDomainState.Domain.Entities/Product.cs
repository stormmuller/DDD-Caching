using System;
using CachedDomainState.Domain.Core;

namespace CachedDomainState.Domain.Entities
{
    public class Product : IEntity
    {
        public Product(string name, decimal buyingPrice, decimal sellingPrice)
        {
            this.Name = name;
            this.BuyingPrice = buyingPrice;
            this.SellingPrice = sellingPrice;
            this.Id = Guid.NewGuid();
        }

        public string Name { get; private set; }
        public decimal BuyingPrice { get; private set; }
        public decimal SellingPrice { get; private set; }
        public Guid Id { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
