using System.Linq;

namespace FluentValidation.Results
{
    public static class ValidationResultExtensions
    {
        public static string ConcatErrorMessages(this ValidationResult result)
        {
            return string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
        }

        public static void HandleResult(this ValidationResult result)
        {
            if (!result.IsValid)
            {
                throw new ValidationException(result.ConcatErrorMessages());
            }
        }
    }
}
