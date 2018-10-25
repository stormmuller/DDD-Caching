namespace CachedDomainState.Domain.Exceptions.OrderExceptions
{
    using System;
    using CachedDomainState.Domain.Entities;

    public class ProductUnavailableException : Exception
    {
        private readonly Product product;

        public ProductUnavailableException(Product product) : base(GenerateMessage(product))
        {
            this.product = product;
        }

        private static string GenerateMessage(Product product)
        {
            return $"The product {product} is unavailable";
        }
    }
}
