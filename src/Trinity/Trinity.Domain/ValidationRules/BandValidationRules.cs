using System;
using FluentValidation;
using Trinity.Domain.Model;

namespace Trinity.Domain.ValidationRules
{
    public class BandValidationRules : AbstractValidator<Band>
    {
        public void CreateInsertingValidationRules()
        {
            CreateNameValidation();
            CreateFoundationYearValidation();
        }

        public void CreateUpdatingValidationRules()
        {
            CreateNameValidation();
            CreateFoundationYearValidation();
        }

        void CreateNameValidation()
        {
            RuleFor(b => b.Name)
                .NotEmpty()
                .WithMessage("Name should not be empty")
                .Length(1, 150)
                .WithMessage("Name length should be 1 to 150 chars long");
        }

        void CreateFoundationYearValidation()
        {
            RuleFor(b => b.FoundationYear)
                .NotEmpty()
                .WithMessage("Foundation Year should not be empty")
                .Must(f => f <= DateTime.Now.Year)
                .WithMessage("Foundation Year should not be a future year");
        }
    }
}
