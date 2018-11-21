using Trinity.Domain.Core.Interfaces;
using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Repositories
{
    public interface IRepository<T> :
        ICreatable<T>,
        IReadable<T>,
        IUpdatable<T>,
        IDeletable<T>
        where T : Entity
    {
        void SaveDbChanges();
    }
}
