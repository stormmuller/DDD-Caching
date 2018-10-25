namespace CachedDomainState.Domain.Core
{
    using System;

    public interface IDataSource<TEntity> where TEntity : IEntity
    {
        TEntity GetEntity(Func<TEntity, bool> filter);
    }
}
