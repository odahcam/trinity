using System;
using System.Collections.Generic;
using System.Linq;
using Trinity.Application.Interfaces;
using Trinity.Application.Model;
using Trinity.Application.Validators;
using Trinity.Domain.Model;
using Trinity.Domain.Repositories;

namespace Trinity.Application.Services
{
    public class AlbumAppService : AppService<Album>, IAlbumAppService
    {
        readonly AlbumValidator Validator;

        public AlbumAppService(
            IAlbumRepository repository,
            AlbumValidator validator
        ) : base(repository)
        {
            Validator = validator;
        }

        public AlbumDisplayingModel Create(AlbumInsertingModel model)
        {
            Validator.Validate(model);
            Album entity = (Album)model;
            Repository.Create(entity);
            Repository.SaveDbChanges();
            if (Exists(entity))
            {
                return (AlbumDisplayingModel)entity;
            }
            throw new InternalServerException("An error ocurred while saving the model");
        }

        public void Delete(long id)
        {
            if (!Exists(id))
            {
                throw new EntityNotFoundException("Entity not found");
            }
            Repository.Delete(id);
            Repository.SaveDbChanges();
            if (Exists(id))
            {
                throw new InternalServerException("An error ocurred while deleting the register");
            }
        }

        public List<AlbumDisplayingModel> GetAll()
        {
            return Repository.GetAll().ToList()
                .Select(m => (AlbumDisplayingModel)m).ToList();
        }

        public AlbumDisplayingModel Get(long id)
        {
            Album entity = Repository.Get(id);
            if (!Exists(entity))
            {
                throw new EntityNotFoundException("Entity not found");
            }
            return (AlbumDisplayingModel)entity;
        }

        public AlbumDisplayingModel Update(AlbumUpdatingModel model)
        {
            Album entity = Repository.Get(model.Id);
            if (!Exists(entity))
            {
                throw new EntityNotFoundException("Entity not found");
            }
            Validator.Validate(model);
            Repository.Update(entity.FromValue((Album)model));
            Repository.SaveDbChanges();
            return (AlbumDisplayingModel)entity;
        }
    }
}
