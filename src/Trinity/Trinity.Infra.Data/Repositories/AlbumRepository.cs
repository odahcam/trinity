using Trinity.Domain.Model;
using Trinity.Domain.Repositories;
using Trinity.Infra.Data.Context;

namespace Trinity.Infra.Data.Repositories
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(TrinityContext db) : base(db)
        {
        }
    }
}
