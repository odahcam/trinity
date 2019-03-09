using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trinity.Domain.Core.Model;
using Trinity.Domain.Repositories;
using Trinity.Infra.Data.Context;

namespace Trinity.Infra.Data.Repositories
{
    public class Repository<TEntity> : Repository<TEntity, long> where TEntity : class, IEntity<long>
    {
        public Repository(IDbContext ctx) : base(ctx)
        {
        }
    }

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected readonly IDbContext Db;

        protected DbSet<TEntity> Set => Db.Set<TEntity>();

        /// <summary>
        /// Por enquanto esse cara já cuida de solicitar a injeção da classe de contexto.
        /// Futuramente isto deve se tornar genérico.
        /// </summary>
        /// <param name="db"></param>
        public Repository(IDbContext db)
        {
            Db = db;
        }

        public void Create(TEntity entity) => Db.Add(entity);

        public void Update(TEntity entity) => Set.Update(entity);

        public void Delete(TKey id) => Set.Remove(Set.Find(id));

        public void Delete(TEntity entity) => Set.Remove(entity);

        public bool Exists(TKey id) => Set.Any(x => x.Id.Equals(id));

        public TEntity Find(TKey id) => Set.Find(id);

        public Task<TEntity> FindAsync(TKey id) => Set.FindAsync(id);

        public List<TEntity> List() => Set.ToList();

        public Task<List<TEntity>> ListAsync() => Set.ToListAsync();

        public int SaveDbChanges() => Db.SaveChanges();

        public Task<int> SaveDbChangesAsync() => Db.SaveChangesAsync();
    }
}
