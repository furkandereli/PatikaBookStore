using FluentValidation;

namespace PatikaBookStore.Validations.GenreValidations
{
    public class GetGenreByIdValidation : AbstractValidator<int>
    {
        public GetGenreByIdValidation() 
        {
            RuleFor(x => x)
                .GreaterThan(0)
                .WithMessage("Id değeri 0dan büyük olmalıdır !");
        }
    }
}
