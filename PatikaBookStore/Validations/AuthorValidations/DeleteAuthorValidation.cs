using FluentValidation;

namespace PatikaBookStore.Validations.AuthorValidations
{
    public class DeleteAuthorValidation : AbstractValidator<int>
    {
        public DeleteAuthorValidation()
        {
            RuleFor(x => x)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
