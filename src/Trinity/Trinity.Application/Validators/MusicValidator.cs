using FluentValidation.Results;
using Trinity.Application.Model;
using Trinity.Domain.Model;
using Trinity.Domain.ValidationRules;

namespace Trinity.Application.Validators
{
    public class MusicValidator : MusicValidationRules
    {
        public void Validate(MusicInsertingModel model)
        {
            CreateInsertingValidationRules();
            Validate((Music)model).HandleResult();
        }

        public void Validate(MusicUpdatingModel model)
        {
            CreateUpdatingValidationRules();
            Validate((Music)model).HandleResult();
        }
    }
}
