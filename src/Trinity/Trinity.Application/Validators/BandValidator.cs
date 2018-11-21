using Trinity.Application.Model;
using Trinity.Domain.Model;
using Trinity.Domain.ValidationRules;
using FluentValidation.Results;

namespace Trinity.Application.Validators
{
    public class BandValidator : BandValidationRules
    {
        public void Validate(BandInsertingModel model)
        {
            CreateInsertingValidationRules();
            Validate((Band)model).HandleResult();
        }

        public void Validate(BandUpdatingModel model)
        {
            CreateUpdatingValidationRules();
            Validate((Band)model).HandleResult();
        }
    }
}
