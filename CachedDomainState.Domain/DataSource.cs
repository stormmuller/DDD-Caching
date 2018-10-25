using CachedDomainState.Common;
using CachedDomainState.Domain.Core;
using CachedDomainState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CachedDomainState.Domain
{
    public class DataSource : IDataSource<Product>
    {
        public DataSource()
        {
            InitializeProducts();
            InitializeSuppliers();
        }

        private List<Product> Products { get; set; } = new List<Product>();
        private List<Supplier> Suppliers { get; set; } = new List<Supplier>();
        private List<Order> Orders { get; set; } = new List<Order>();

        private void InitializeProducts()
        {
            Products.Add(new Product("Blue Pen", 5m, 6.5m));
            Products.Add(new Product("Black Pen", 5m, 6.5m));
            Products.Add(new Product("Red Pen", 5m, 6.5m));
            Products.Add(new Product("Pencil", 2m, 3m));
            Products.Add(new Product("Marker", 7m, 11m));
            Products.Add(new Product("Eraser", 0.5m, 1.5m));
        }

        private void InitializeSuppliers()
        {
            InitializeSupplier("School Shop");
            InitializeSupplier("Books n Pens");
            InitializeSupplier("Art Station");
        }

        private void InitializeSupplier(string name)
        {
            var randomGenerator = new Random();
            var amountOfProductsToAdd = randomGenerator.Next(0, 10);

            var supplier = new Supplier(name, $"{name.RemoveWhitespace()}@mail.com");

            for (int i = 0; i < amountOfProductsToAdd; i++)
            {
                var productIndex = randomGenerator.Next(0, Products.Count);

                supplier.AddProductToStockList(Products[productIndex]);
            }

            Suppliers.Add(supplier);
        }

        public Product GetEntity(Func<Product, bool> filter)
        {
            Thread.Sleep(5000);

            return Products.FirstOrDefault(filter);
        }
    }
}
