using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Core.Interfaces
{
    public interface IDeletable<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        void Delete(TKey id);
        
        void Delete(TEntity entity);
    }
}
