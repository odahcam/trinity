using System.Collections.Generic;
using Trinity.Application.Model;
using Trinity.Domain.Model;

namespace Trinity.Application.Interfaces
{
    public interface IMusicAppService : IAppService<Music>
    {
        MusicDisplayingModel Create(MusicInsertingModel model);
        MusicDisplayingModel Update(MusicUpdatingModel model);
        List<MusicDisplayingModel> GetAll();
        MusicDisplayingModel Get(long id);
        void Delete(long id);
    }
}
