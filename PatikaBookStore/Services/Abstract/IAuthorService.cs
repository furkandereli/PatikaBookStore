using PatikaBookStore.DTOs.AuthorDtos;

namespace PatikaBookStore.Services.Abstract
{
    public interface IAuthorService
    {
        Task<List<ResultAuthorDto>> GetAllAuthorAsync();
        Task CreateAuthorAsync(CreateAuthorDto createAuthorDto);
        Task UpdateAuthorAsync(UpdateAuthorDto updateAuthorDto);
        Task DeleteAuthorAsync(int authorId);
        Task<GetAuthorByIdDto> GetByIdAuthorAsync(int authorId);
    }
}
