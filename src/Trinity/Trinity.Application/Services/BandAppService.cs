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
    public class BandAppService : AppService<Band>, IBandAppService
    {
        readonly BandValidator Validator;

        public BandAppService(
            IBandRepository repository,
            BandValidator validator
        ) : base(repository)
        {
            Validator = validator;
        }

        public BandDisplayingModel Create(BandInsertingModel model)
        {
            Validator.Validate(model);
            Band entity = (Band)model;
            Repository.Create(entity);
            Repository.SaveDbChanges();
            if (Exists(entity))
            {
                return (BandDisplayingModel)entity;
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

        public List<BandDisplayingModel> GetAll()
        {
            return Repository.GetAll().ToList()
                .Select(m => (BandDisplayingModel)m).ToList();
        }

        public BandDisplayingModel Get(long id)
        {
            Band entity = Repository.Get(id);
            if (!Exists(entity))
            {
                throw new EntityNotFoundException("Entity not found");
            }
            return (BandDisplayingModel)entity;
        }

        public BandDisplayingModel Update(BandUpdatingModel model)
        {
            Band entity = Repository.Get(model.Id);
            if (!Exists(entity))
            {
                throw new EntityNotFoundException("Entity not found");
            }
            Validator.Validate(model);
            Repository.Update(entity.FromValue((Band)model));
            Repository.SaveDbChanges();
            return (BandDisplayingModel)entity;
        }
    }
}
