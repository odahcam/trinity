using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Core.Interfaces
{
    public interface IReadable<TEntity> : IReadable<TEntity, long> where TEntity : class, IEntity<long> { }

    public interface IReadable<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        List<TEntity> List();

        Task<List<TEntity>> ListAsync();

        TEntity Find(TKey id);

        Task<TEntity> FindAsync(TKey id);

        bool Exists(TKey id);
    }
}
