using PatikaBookStore.DTOs.BookDtos;
using PatikaBookStore.Validations.BookValidations;

namespace BookStoreTests.BookTests
{
    public class BookValidationTests
    {
        private readonly CreateBookValidation _createBookValidator;
        private readonly DeleteBookValidation _deleteBookValidator;
        private readonly GetBookByIdValidation _getBookByIdValidator;
        private readonly UpdateBookValidation _updateBookValidator;

        public BookValidationTests()
        {
            _createBookValidator = new CreateBookValidation();
            _deleteBookValidator = new DeleteBookValidation();
            _getBookByIdValidator = new GetBookByIdValidation();
            _updateBookValidator = new UpdateBookValidation();
        }

        [Fact]
        public void CreateBookValidation_Should_Pass_When_Valid_Data()
        {
            // Arrange
            var dto = new CreateBookDto { Title = "Valid Title", PageCount = 150, AuthorId = 1, GenreId = 1 };

            // Act
            var result = _createBookValidator.Validate(dto);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void CreateBookValidation_Should_Fail_When_Title_Is_Empty()
        {
            // Arrange
            var dto = new CreateBookDto { Title = "", PageCount = 150, AuthorId = 1, GenreId = 1 };

            // Act
            var result = _createBookValidator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Title");
        }

        [Fact]
        public void CreateBookValidation_Should_Fail_When_PageCount_Is_Out_Of_Range()
        {
            // Arrange
            var dto = new CreateBookDto { Title = "Valid Title", PageCount = 3000, AuthorId = 1, GenreId = 1 };

            // Act
            var result = _createBookValidator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "PageCount");
        }

        [Fact]
        public void DeleteBookValidation_Should_Pass_When_Valid_Id()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _deleteBookValidator.Validate(id);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void DeleteBookValidation_Should_Fail_When_Id_Is_Zero()
        {
            // Arrange
            var id = 0;

            // Act
            var result = _deleteBookValidator.Validate(id);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void DeleteBookValidation_Should_Fail_When_Id_Is_Negative()
        {
            // Arrange
            var id = -1;

            // Act
            var result = _deleteBookValidator.Validate(id);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void GetBookByIdValidation_Should_Pass_When_Valid_Id()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _getBookByIdValidator.Validate(id);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void GetBookByIdValidation_Should_Fail_When_Id_Is_Zero()
        {
            // Arrange
            var id = 0;

            // Act
            var result = _getBookByIdValidator.Validate(id);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void GetBookByIdValidation_Should_Fail_When_Id_Is_Negative()
        {
            // Arrange
            var id = -1;

            // Act
            var result = _getBookByIdValidator.Validate(id);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void UpdateBookValidation_Should_Pass_When_Valid_Data()
        {
            // Arrange
            var dto = new UpdateBookDto { Id = 1, Title = "Valid Title", PageCount = 150, AuthorId = 1, GenreId = 1 };

            // Act
            var result = _updateBookValidator.Validate(dto);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void UpdateBookValidation_Should_Fail_When_Title_Is_Empty()
        {
            // Arrange
            var dto = new UpdateBookDto { Id = 1, Title = "", PageCount = 150, AuthorId = 1, GenreId = 1 };

            // Act
            var result = _updateBookValidator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Title");
        }

        [Fact]
        public void UpdateBookValidation_Should_Fail_When_PageCount_Is_Out_Of_Range()
        {
            // Arrange
            var dto = new UpdateBookDto { Id = 1, Title = "Valid Title", PageCount = 3000, AuthorId = 1, GenreId = 1 };

            // Act
            var result = _updateBookValidator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "PageCount");
        }
    }
}
