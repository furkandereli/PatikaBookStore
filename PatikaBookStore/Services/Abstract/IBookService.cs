using PatikaBookStore.DTOs.BookDtos;

namespace PatikaBookStore.Services.Abstract
{
    public interface IBookService
    {
        Task<List<ResultBookDto>> GetAllBookAsync();
        Task CreateBookAsync(CreateBookDto createBookDto);
        Task UpdateBookAsync(UpdateBookDto updateBookDto);
        Task DeleteBookAsync(int bookId);
        Task<GetBookByIdDto> GetByIdBookAsync(int bookId);
    }
}
