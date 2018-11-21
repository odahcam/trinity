using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Core.Interfaces
{
    public interface ICreatable<T> where T : Entity
    {
        void Create(T model);
    }
}
