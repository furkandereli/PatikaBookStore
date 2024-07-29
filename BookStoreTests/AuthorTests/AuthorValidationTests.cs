using FluentValidation.TestHelper;
using PatikaBookStore.DTOs.AuthorDtos;
using PatikaBookStore.Validations.AuthorValidations;

namespace BookStoreTests.AuthorTests
{
    public class AuthorValidationTests 
    {
        private readonly CreateAuthorValidation _createAuthorValidation;
        private readonly DeleteAuthorValidation _deleteAuthorValidation;
        private readonly UpdateAuthorValidation _updateAuthorValidation;
        private readonly GetAuthorByIdValidation _getAuthorByIdValidation;

        public AuthorValidationTests()
        {
            _createAuthorValidation = new CreateAuthorValidation();
            _deleteAuthorValidation = new DeleteAuthorValidation();
            _updateAuthorValidation = new UpdateAuthorValidation();
            _getAuthorByIdValidation = new GetAuthorByIdValidation();
        }

        [Fact]
        public void CreateAuthorValidation_Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new CreateAuthorDto { Name = "", Surname = "Doe", BirthDate = new DateTime(1980, 1, 1) };
            var result = _createAuthorValidation.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void CreateAuthorValidation_Should_Have_Error_When_Name_Is_Less_Than_3_Characters()
        {
            var model = new CreateAuthorDto { Name = "Jo", Surname = "Doe", BirthDate = new DateTime(1980, 1, 1) };
            var result = _createAuthorValidation.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void CreateAuthorValidation_Should_Not_Have_Error_When_Name_Is_Valid()
        {
            var model = new CreateAuthorDto { Name = "John", Surname = "Doe", BirthDate = new DateTime(1980, 1, 1) };
            var result = _createAuthorValidation.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        // DeleteAuthorValidation Tests
        [Fact]
        public void DeleteAuthorValidation_Should_Have_Error_When_Id_Is_Zero()
        {
            var result = _deleteAuthorValidation.TestValidate(0);
            result.ShouldHaveValidationErrorFor(x => x);
        }

        [Fact]
        public void DeleteAuthorValidation_Should_Have_Error_When_Id_Is_Negative()
        {
            var result = _deleteAuthorValidation.TestValidate(-1);
            result.ShouldHaveValidationErrorFor(x => x);
        }

        // UpdateAuthorValidation Tests
        [Fact]
        public void UpdateAuthorValidation_Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new UpdateAuthorDto { Id = 1, Name = "", Surname = "Doe", BirthDate = new DateTime(1980, 1, 1) };
            var result = _updateAuthorValidation.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void UpdateAuthorValidation_Should_Have_Error_When_Id_Is_Zero()
        {
            var model = new UpdateAuthorDto { Id = 0, Name = "John", Surname = "Doe", BirthDate = new DateTime(1980, 1, 1) };
            var result = _updateAuthorValidation.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void UpdateAuthorValidation_Should_Not_Have_Error_When_Data_Is_Valid()
        {
            var model = new UpdateAuthorDto { Id = 1, Name = "John", Surname = "Doe", BirthDate = new DateTime(1980, 1, 1) };
            var result = _updateAuthorValidation.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
            result.ShouldNotHaveValidationErrorFor(x => x.Surname);
            result.ShouldNotHaveValidationErrorFor(x => x.BirthDate);
        }

        // GetAuthorByIdValidation Tests
        [Fact]
        public void GetAuthorByIdValidation_Should_Have_Error_When_Id_Is_Zero()
        {
            var result = _getAuthorByIdValidation.TestValidate(0);
            result.ShouldHaveValidationErrorFor(x => x).WithErrorMessage("Id değeri 0dan büyük olmalıdır !");
        }
    }
}
