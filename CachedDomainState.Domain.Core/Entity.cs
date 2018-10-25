using System;

namespace CachedDomainState.Domain.Core
{
    public class Entity : IEntity
    {
        public Entity(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }
}
