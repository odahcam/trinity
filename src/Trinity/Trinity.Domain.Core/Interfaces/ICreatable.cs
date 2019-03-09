using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Core.Interfaces
{
    public interface ICreatable<in TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        void Create(TEntity entity);
    }
}

