using Trinity.Domain.Core.Interfaces;
using Trinity.Domain.Core.Model;
using System.Threading.Tasks;

namespace Trinity.Domain.Repositories
{
    public interface IRepository<TEntity, TKey> :
        ICreatable<TEntity, TKey>,
        IReadable<TEntity, TKey>,
        IUpdatable<TEntity, TKey>,
        IDeletable<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        int SaveDbChanges();
        Task<int> SaveDbChangesAsync();
    }

    public interface IRepository<TEntity> : IRepository<TEntity, long>  where TEntity : class, IEntity<long>
    { }
}
