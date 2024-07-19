using FluentValidation;
using PatikaBookStore.DTOs.GenreDtos;

namespace PatikaBookStore.Validations.GenreValidations
{
    public class UpdateGenreValidation : AbstractValidator<UpdateGenreDto>
    {
        public UpdateGenreValidation()
        {
            RuleFor(g => g.Id)
                .NotEmpty();

            RuleFor(g => g.Name)
                .NotEmpty()
                .Length(3, 30)
                .WithMessage("Name must be between 3-30 characters !");
        }
    }
}
