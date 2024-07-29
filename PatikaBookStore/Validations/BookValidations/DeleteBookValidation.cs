using FluentValidation;

namespace PatikaBookStore.Validations.BookValidations
{
    public class DeleteBookValidation : AbstractValidator<int>
    {
        public DeleteBookValidation () 
        {
            RuleFor(x => x)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
