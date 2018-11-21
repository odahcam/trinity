using System.Linq;
using Trinity.Domain.Core.Model;

namespace Trinity.Domain.Core.Interfaces
{
    public interface IReadable<T> where T : Entity
    {
        IQueryable<T> GetAll();
        T Get(long id);
    }
}
