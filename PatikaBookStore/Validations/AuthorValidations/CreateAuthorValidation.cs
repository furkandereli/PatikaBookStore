using FluentValidation;
using PatikaBookStore.DTOs.AuthorDtos;

namespace PatikaBookStore.Validations.AuthorValidations
{
    public class CreateAuthorValidation : AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorValidation()
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
