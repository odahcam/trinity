using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Core.Interfaces
{
    public interface IDeletable<T> where T : Entity
    {
        void Delete(long id);
    }
}
