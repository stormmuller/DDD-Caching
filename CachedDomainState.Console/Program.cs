namespace CachedDomainState
{
    using System;
    using CachedDomainState.Domain;
    using CachedDomainState.Domain.Entities;

    class Program
    {
        static void Main(string[] args)
        {
            var dataSource = new EntityCache<Product>(new DataSource());

            Console.WriteLine(dataSource.GetEntity(e => e.Name.Contains("Black Pen")));
            Console.WriteLine(dataSource.GetEntity(e => e.Name.Contains("Black Pen")));

            Console.ReadKey();
        }
    }
}
