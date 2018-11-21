using Trinity.Domain.Core.Model;

namespace Trinity.Application.Interfaces
{
    public interface IAppService<T> where T : Entity
    {
        bool Exists(long id);
        bool Exists(T entity);
    }
}
