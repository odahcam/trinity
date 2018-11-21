using Trinity.Domain.Model;
using Trinity.Domain.Repositories;
using Trinity.Infra.Data.Context;

namespace Trinity.Infra.Data.Repositories
{
    public class BandRepository : Repository<Band>, IBandRepository
    {
        public BandRepository(TrinityContext db) : base(db)
        {
        }
    }
}
