using PatikaBookStore.DTOs.GenreDtos;

namespace PatikaBookStore.Services.Abstract
{
    public interface IGenreService
    {
        Task<List<ResultGenreDto>> GetAllGenreAsync();
        Task CreateGenreAsync(CreateGenreDto createGenreDto);
        Task UpdateGenreAsync(UpdateGenreDto updateGenreDto);
        Task DeleteGenreAsync(int genreId);
        Task<GetGenreByIdDto> GetByIdGenreAsync(int genreId);
    }
}
