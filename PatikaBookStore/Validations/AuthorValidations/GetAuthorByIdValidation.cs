using FluentValidation;

namespace PatikaBookStore.Validations.AuthorValidations
{
    public class GetAuthorByIdValidation : AbstractValidator<int>
    {
        public GetAuthorByIdValidation()
        {
            RuleFor(x => x)
                .GreaterThan(0)
                .WithMessage("Id değeri 0dan büyük olmalıdır !");
        }
    }
}
