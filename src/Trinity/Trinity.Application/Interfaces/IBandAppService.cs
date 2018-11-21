using System.Collections.Generic;
using Trinity.Application.Model;
using Trinity.Domain.Model;

namespace Trinity.Application.Interfaces
{
    public interface IBandAppService : IAppService<Band>
    {
        BandDisplayingModel Create(BandInsertingModel model);
        BandDisplayingModel Update(BandUpdatingModel model);
        List<BandDisplayingModel> GetAll();
        BandDisplayingModel Get(long id);
        void Delete(long id);
    }
}
