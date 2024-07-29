using FluentValidation;

namespace PatikaBookStore.Validations.GenreValidations
{
    public class DeleteGenreValidation : AbstractValidator<int>
    {
        public DeleteGenreValidation()
        {
            RuleFor(x => x)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
