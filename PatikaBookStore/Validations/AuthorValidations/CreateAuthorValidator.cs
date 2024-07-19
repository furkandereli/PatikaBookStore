using FluentValidation;
using PatikaBookStore.DTOs.AuthorDtos;

namespace PatikaBookStore.Validations.AuthorValidations
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("You must enter at least 3 characters for the name !");

            RuleFor(a => a.Surname)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(a => a.BirthDate)
                .NotEmpty();
        }
    }
}
