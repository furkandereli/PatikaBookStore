using PatikaBookStore.DTOs.GenreDtos;
using PatikaBookStore.Validations.GenreValidations;

namespace BookStoreTests.GenreTests
{
    public class GenreValidationTests
    {
        private readonly CreateGenreValidation _createGenreValidator;
        private readonly DeleteGenreValidation _deleteGenreValidator;
        private readonly GetGenreByIdValidation _getGenreByIdValidator;
        private readonly UpdateGenreValidation _updateGenreValidator;

        public GenreValidationTests()
        {
            _createGenreValidator = new CreateGenreValidation();
            _deleteGenreValidator = new DeleteGenreValidation();
            _getGenreByIdValidator = new GetGenreByIdValidation();
            _updateGenreValidator = new UpdateGenreValidation();
        }

        [Fact]
        public void CreateGenreValidation_Should_Pass_When_Valid_Data()
        {
            // Arrange
            var dto = new CreateGenreDto { Name = "Valid Genre" };

            // Act
            var result = _createGenreValidator.Validate(dto);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void CreateGenreValidation_Should_Fail_When_Name_Is_Empty()
        {
            // Arrange
            var dto = new CreateGenreDto { Name = "" };

            // Act
            var result = _createGenreValidator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Name" && e.ErrorMessage == "Name must be between 3-30 characters !");
        }

        [Fact]
        public void CreateGenreValidation_Should_Fail_When_Name_Is_Too_Short()
        {
            // Arrange
            var dto = new CreateGenreDto { Name = "AB" };

            // Act
            var result = _createGenreValidator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Name" && e.ErrorMessage == "Name must be between 3-30 characters !");
        }

        [Fact]
        public void DeleteGenreValidation_Should_Pass_When_Valid_Id()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _deleteGenreValidator.Validate(id);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void DeleteGenreValidation_Should_Fail_When_Id_Is_Zero()
        {
            // Arrange
            var id = 0;

            // Act
            var result = _deleteGenreValidator.Validate(id);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void DeleteGenreValidation_Should_Fail_When_Id_Is_Negative()
        {
            // Arrange
            var id = -1;

            // Act
            var result = _deleteGenreValidator.Validate(id);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void GetGenreByIdValidation_Should_Pass_When_Valid_Id()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _getGenreByIdValidator.Validate(id);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void GetGenreByIdValidation_Should_Fail_When_Id_Is_Zero()
        {
            // Arrange
            var id = 0;

            // Act
            var result = _getGenreByIdValidator.Validate(id);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void GetGenreByIdValidation_Should_Fail_When_Id_Is_Negative()
        {
            // Arrange
            var id = -1;

            // Act
            var result = _getGenreByIdValidator.Validate(id);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void UpdateGenreValidation_Should_Pass_When_Valid_Data()
        {
            // Arrange
            var dto = new UpdateGenreDto { Id = 1, Name = "Valid Genre" };

            // Act
            var result = _updateGenreValidator.Validate(dto);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void UpdateGenreValidation_Should_Fail_When_Name_Is_Empty()
        {
            // Arrange
            var dto = new UpdateGenreDto { Id = 1, Name = "" };

            // Act
            var result = _updateGenreValidator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Name" && e.ErrorMessage == "Name must be between 3-30 characters !");
        }

        [Fact]
        public void UpdateGenreValidation_Should_Fail_When_Name_Is_Too_Short()
        {
            // Arrange
            var dto = new UpdateGenreDto { Id = 1, Name = "AB" };

            // Act
            var result = _updateGenreValidator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Name" && e.ErrorMessage == "Name must be between 3-30 characters !");
        }
    }
}
