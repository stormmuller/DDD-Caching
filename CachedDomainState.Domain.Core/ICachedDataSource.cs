namespace CachedDomainState.Domain.Core
{
    public interface ICachedDataSource<TEntity> : IDataSource<TEntity> where TEntity : IEntity
    {

    }
}
