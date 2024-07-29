using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using PatikaBookStore.Context;
using PatikaBookStore.DTOs.AuthorDtos;
using PatikaBookStore.Entities;
using PatikaBookStore.Services.Concrete;

namespace BookStoreTests.AuthorTests
{
    public class AuthorServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;

        public AuthorServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
        }

        private PatikaDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<PatikaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new PatikaDbContext(options);
            return context;
        }


        [Fact]
        public async Task GetAllAuthorAsync_Should_Return_All_Authors()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var authorService = new AuthorService(context, _mockMapper.Object);

            var authors = new List<Author>
            {
                new Author { Id = 1, Name = "John", Surname = "Doe", BirthDate = new DateTime(1980, 1, 1) },
                new Author { Id = 2, Name = "Jane", Surname = "Doe", BirthDate = new DateTime(1990, 1, 1) }
            };

            context.Authors.AddRange(authors);
            await context.SaveChangesAsync();

            var resultAuthors = new List<ResultAuthorDto>
            {
                new ResultAuthorDto { Id = 1, Name = "John", Surname = "Doe" },
                new ResultAuthorDto { Id = 2, Name = "Jane", Surname = "Doe" }
            };

            _mockMapper.Setup(m => m.Map<List<ResultAuthorDto>>(authors)).Returns(resultAuthors);

            // Act
            var result = await authorService.GetAllAuthorAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].Name);
            Assert.Equal("Jane", result[1].Name);
        }

        [Fact]
        public async Task GetByIdAuthorAsync_Should_Return_Author_By_Id()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var authorService = new AuthorService(context, _mockMapper.Object);

            var authorId = 1;
            var author = new Author 
            { 
                Id = authorId, 
                Name = "John", 
                Surname = "Doe", 
                BirthDate = new DateTime(1980, 1, 1) 
            };

            context.Authors.Add(author);
            await context.SaveChangesAsync();

            var resultAuthor = new GetAuthorByIdDto 
            { 
                Id = authorId, 
                Name = "John", 
                Surname = "Doe" 
            };

            _mockMapper.Setup(m => m.Map<GetAuthorByIdDto>(author)).Returns(resultAuthor);

            // Act
            var result = await authorService.GetByIdAuthorAsync(authorId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.Name);
            Assert.Equal("Doe", result.Surname);
        }
        
        [Fact]
        public async Task CreateAuthorAsync_Should_Create_Author()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var authorService = new AuthorService(context, _mockMapper.Object);

            var createAuthorDto = new CreateAuthorDto
            { 
                Name = "John", 
                Surname = "Doe", 
                BirthDate = new DateTime(1980, 1, 1) 
            };
            
            var author = new Author 
            { 
                Id = 1, 
                Name = "John", 
                Surname = "Doe", 
                BirthDate = new DateTime(1980, 1, 1) 
            };

            _mockMapper.Setup(m => m.Map<Author>(createAuthorDto)).Returns(author);

            // Act
            await authorService.CreateAuthorAsync(createAuthorDto);

            // Assert
            var createdAuthor = await context.Authors.FirstOrDefaultAsync(a => a.Name == "John" && a.Surname == "Doe");
            Assert.NotNull(createdAuthor);
            Assert.Equal("John", createdAuthor.Name);
            Assert.Equal("Doe", createdAuthor.Surname);
            Assert.Equal(new DateTime(1980, 1, 1), createdAuthor.BirthDate);
        }

        [Fact]
        public async Task DeleteAuthorAsync_Should_Delete_Author()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var authorService = new AuthorService(context, _mockMapper.Object);

            var authorId = 1;
            var author = new Author { Id = authorId, Name = "John", Surname = "Doe", BirthDate = new DateTime(1980, 1, 1) };

            context.Authors.Add(author);
            await context.SaveChangesAsync();

            // Act
            await authorService.DeleteAuthorAsync(authorId);

            // Assert
            var deletedAuthor = await context.Authors.FindAsync(authorId);
            Assert.Null(deletedAuthor);
        }
        
        [Fact]
        public async Task UpdateAuthorAsync_Should_Update_Author()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var authorService = new AuthorService(context, _mockMapper.Object);

            var authorId = 1;
            var author = new Author 
            { 
                Id = authorId, 
                Name = "John", 
                Surname = "Doe", 
                BirthDate = new DateTime(1980, 1, 1) 
            };

            context.Authors.Add(author);
            await context.SaveChangesAsync();

            var updateAuthorDto = new UpdateAuthorDto 
            { 
                Id = authorId, 
                Name = "John Updated", 
                Surname = "Doe Updated", 
                BirthDate = new DateTime(1980, 1, 1) 
            };

            author.Id = updateAuthorDto.Id;
            author.Name = updateAuthorDto.Name;
            author.Surname = updateAuthorDto.Surname;
            author.BirthDate = updateAuthorDto.BirthDate;

            // Act
            await authorService.UpdateAuthorAsync(updateAuthorDto);

            // Assert
            var updatedAuthor = await context.Authors.FindAsync(authorId);
            Assert.NotNull(updatedAuthor);
            Assert.Equal("John Updated", updatedAuthor.Name);
            Assert.Equal("Doe Updated", updatedAuthor.Surname);
        }
    }
}
