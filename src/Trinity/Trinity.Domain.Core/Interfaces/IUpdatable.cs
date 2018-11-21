using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Core.Interfaces
{
    public interface IUpdatable<T> where T : Entity
    {
        void Update(T model);
    }
}
