namespace CachedDomainState.Domain
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using CachedDomainState.Domain.Core;

    public class EntityCache<TEntity> : IDataSource<TEntity> where TEntity : IEntity
    {
        private readonly IDataSource<TEntity> dataSource;
        private readonly HashSet<TEntity> Entities = new HashSet<TEntity>();

        public EntityCache(IDataSource<TEntity> dataSource)
        {
            this.dataSource = dataSource;
        }

        public TEntity GetEntity(Func<TEntity, bool> filter)
        {
            if (Entities.Any(filter))
            {
                return Entities.First(filter);
            }

            var valueFromDataSource = this.dataSource.GetEntity(filter);

            Entities.Add(valueFromDataSource);

            return valueFromDataSource;
        }
    }
}
