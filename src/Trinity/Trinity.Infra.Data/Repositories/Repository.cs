using System.Linq;
using Microsoft.EntityFrameworkCore;
using Trinity.Domain.Core.Model;
using Trinity.Domain.Repositories;
using Trinity.Infra.Data.Context;

namespace Trinity.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly TrinityContext Db;
        protected readonly DbSet<T> Set;

        public Repository(TrinityContext db)
        {
            Db = db;
            Set = Db.Set<T>();
        }

        public void Create(T model)
        {
            Db.Add(model);
        }

        public void Delete(long id)
        {
            Set.Remove(Set.Find(id));
        }

        public T Get(long id)
        {
            return Set.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return Set;
        }

        public void SaveDbChanges()
        {
            Db.SaveChanges();
        }

        public void Update(T model)
        {
            Set.Update(model);
        }
    }
}
