using FluentValidation.Results;
using Trinity.Application.Model;
using Trinity.Domain.Model;
using Trinity.Domain.ValidationRules;

namespace Trinity.Application.Validators
{
    public class AlbumValidator : AlbumValidationRules
    {
        public void Validate(AlbumInsertingModel model)
        {
            CreateInsertingValidationRules();
            Validate((Album)model).HandleResult();
        }

        public void Validate(AlbumUpdatingModel model)
        {
            CreateUpdatingValidationRules();
            Validate((Album)model).HandleResult();
        }
    }
}
