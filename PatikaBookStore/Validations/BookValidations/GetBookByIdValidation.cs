using FluentValidation;

namespace PatikaBookStore.Validations.BookValidations
{
    public class GetBookByIdValidation : AbstractValidator<int>
    {
        public GetBookByIdValidation()
        {
            RuleFor(x => x)
                .GreaterThan(0)
                .WithMessage("Id değeri 0dan büyük olmalıdır !");
        }
    }
}
