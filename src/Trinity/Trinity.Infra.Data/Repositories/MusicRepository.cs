using Trinity.Domain.Model;
using Trinity.Domain.Repositories;
using Trinity.Infra.Data.Context;

namespace Trinity.Infra.Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(TrinityContext db) : base(db)
        {
        }
    }
}
