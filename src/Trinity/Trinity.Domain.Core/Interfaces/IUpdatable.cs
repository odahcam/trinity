using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Core.Interfaces
{
    public interface IUpdatable<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        void Update(TEntity entity);
    }
}
