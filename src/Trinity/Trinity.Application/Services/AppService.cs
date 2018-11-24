using Trinity.Application.Interfaces;
using Trinity.Domain.Core.Model;
using Trinity.Domain.Repositories;

namespace Trinity.Application.Services
{
    public abstract class AppService<T> : IAppService<T> where T : Entity
    {
        protected readonly IRepository<T> Repository;

        public AppService(IRepository<T> repository)
        {
            Repository = repository;
        }

        public bool Exists(long id)
        {
            T entity = Repository.Get(id);
            return entity != null && entity.Id > 0;
        }

        public bool Exists(T entity)
        {
            return entity != null && entity.Id > 0;
        }
    }
}
