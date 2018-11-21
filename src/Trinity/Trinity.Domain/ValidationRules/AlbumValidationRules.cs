using FluentValidation;
using Trinity.Domain.Model;

namespace Trinity.Domain.ValidationRules
{
    public class AlbumValidationRules : AbstractValidator<Album>
    {

        public void CreateInsertingValidationRules()
        {
            CreateTitleValidation();
        }

        public void CreateUpdatingValidationRules()
        {
            CreateTitleValidation();
        }

        void CreateTitleValidation()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .WithMessage("Album should not be empty")
                .Length(1, 150)
                .WithMessage("Name length should be 1 to 150 chars long");
        }
    }
}
