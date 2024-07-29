using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using PatikaBookStore.Context;
using PatikaBookStore.DTOs.GenreDtos;
using PatikaBookStore.Entities;
using PatikaBookStore.Exceptions;
using PatikaGenreStore.Services.Concrete;

namespace BookStoreTests.GenreTests
{
    public class GenreServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;

        public GenreServiceTests()
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
        public async Task CreateGenreAsync_Should_Add_Genre()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new GenreService(context, _mockMapper.Object);
            var createGenreDto = new CreateGenreDto { Name = "Test Genre" };
            var genre = new Genre { Name = "Test Genre" };
            _mockMapper.Setup(m => m.Map<Genre>(createGenreDto)).Returns(genre);

            // Act
            await service.CreateGenreAsync(createGenreDto);

            // Assert
            var addedGenre = await context.Genres.FirstOrDefaultAsync(g => g.Name == "Test Genre");
            Assert.NotNull(addedGenre);
            Assert.Equal("Test Genre", addedGenre.Name);
        }

        [Fact]
        public async Task DeleteGenreAsync_Should_Remove_Genre_When_Genre_Exists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new GenreService(context, _mockMapper.Object);
            var genre = new Genre { Name = "Test Genre" };
            context.Genres.Add(genre);
            await context.SaveChangesAsync();

            // Act
            await service.DeleteGenreAsync(genre.Id);

            // Assert
            var deletedGenre = await context.Genres.FindAsync(genre.Id);
            Assert.Null(deletedGenre);
        }

        [Fact]
        public async Task GetAllGenreAsync_Should_Return_All_Genres()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new GenreService(context, _mockMapper.Object);
            var genres = new List<Genre>
        {
            new Genre { Name = "Genre 1" },
            new Genre { Name = "Genre 2" }
        };
            context.Genres.AddRange(genres);
            await context.SaveChangesAsync();
            var resultGenres = genres.Select(g => new ResultGenreDto { Id = g.Id, Name = g.Name }).ToList();
            _mockMapper.Setup(m => m.Map<List<ResultGenreDto>>(genres)).Returns(resultGenres);

            // Act
            var result = await service.GetAllGenreAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, g => g.Name == "Genre 1");
            Assert.Contains(result, g => g.Name == "Genre 2");
        }

        [Fact]
        public async Task GetByIdGenreAsync_Should_Return_Genre_When_Genre_Exists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new GenreService(context, _mockMapper.Object);
            var genre = new Genre { Name = "Test Genre" };
            context.Genres.Add(genre);
            await context.SaveChangesAsync();
            var resultGenre = new GetGenreByIdDto { Id = genre.Id, Name = genre.Name };
            _mockMapper.Setup(m => m.Map<GetGenreByIdDto>(genre)).Returns(resultGenre);

            // Act
            var result = await service.GetByIdGenreAsync(genre.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(genre.Name, result.Name);
        }

        [Fact]
        public async Task GetByIdGenreAsync_Should_Throw_NotFoundException_When_Genre_Does_Not_Exist()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new GenreService(context, _mockMapper.Object);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => service.GetByIdGenreAsync(1));
        }

        [Fact]
        public async Task UpdateGenreAsync_Should_Update_Genre_When_Genre_Exists()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new GenreService(context, _mockMapper.Object);
            var genre = new Genre { Name = "Original Name" };
            context.Genres.Add(genre);
            await context.SaveChangesAsync();

            var updateGenreDto = new UpdateGenreDto { Id = genre.Id, Name = "Updated Name" };
            _mockMapper.Setup(m => m.Map(updateGenreDto, genre)).Callback(() =>
            {
                genre.Name = updateGenreDto.Name;
            });

            // Act
            await service.UpdateGenreAsync(updateGenreDto);

            // Assert
            var updatedGenre = await context.Genres.FindAsync(genre.Id);
            Assert.NotNull(updatedGenre);
            Assert.Equal("Updated Name", updatedGenre.Name);
        }

        [Fact]
        public async Task UpdateGenreAsync_Should_Throw_NotFoundException_When_Genre_Does_Not_Exist()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new GenreService(context, _mockMapper.Object);
            var updateGenreDto = new UpdateGenreDto { Id = 1, Name = "Updated Name" };

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => service.UpdateGenreAsync(updateGenreDto));
        }
    }
}
