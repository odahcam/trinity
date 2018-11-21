using FluentValidation;
using Trinity.Domain.Model;

namespace Trinity.Domain.ValidationRules
{
    public class MusicValidationRules : AbstractValidator<Music>
    {
        public void CreateInsertingValidationRules()
        {
            CreateTitleValidation();
            CreateDurationValidation();
            CreateBandIdValidation();
        }

        public void CreateUpdatingValidationRules()
        {
            CreateTitleValidation();
            CreateBandIdValidation();
        }

        void CreateTitleValidation()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Title should not be empty")
                .Length(1, 150)
                .WithMessage("Title length should be 1 to 150 chars long");
        }

        void CreateBandIdValidation()
        {
            RuleFor(m => m.BandId)
                .NotEmpty()
                .WithMessage("Band should not be empty");
        }

        void CreateDurationValidation()
        {
            RuleFor(m => m.Duration)
                .NotEmpty()
                .WithMessage("Duration should not be empty");
        }
    }
}
