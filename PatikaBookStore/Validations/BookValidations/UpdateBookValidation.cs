using FluentValidation;
using PatikaBookStore.DTOs.BookDtos;

namespace PatikaBookStore.Validations.BookValidations
{
    public class UpdateBookValidation : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookValidation()
        {
            RuleFor(b => b.Id)
                .NotEmpty();

            RuleFor(b => b.Title)
                .NotEmpty()
                .Length(2, 100);

            RuleFor(b => b.PageCount)
                .NotEmpty()
                .InclusiveBetween(1,2000);
        }
    }
}
