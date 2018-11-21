using System.Collections.Generic;
using Trinity.Application.Model;
using Trinity.Domain.Model;

namespace Trinity.Application.Interfaces
{
    public interface IAlbumAppService : IAppService<Album>
    {
        AlbumDisplayingModel Create(AlbumInsertingModel model);
        AlbumDisplayingModel Update(AlbumUpdatingModel model);
        List<AlbumDisplayingModel> GetAll();
        AlbumDisplayingModel Get(long id);
        void Delete(long id);
    }
}
