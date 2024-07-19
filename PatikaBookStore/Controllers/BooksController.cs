using Microsoft.AspNetCore.Mvc;
using PatikaBookStore.DTOs.AuthorDtos;
using PatikaBookStore.DTOs.BookDtos;
using PatikaBookStore.Entities;
using PatikaBookStore.Services.Abstract;
using PatikaBookStore.Services.Concrete;

namespace PatikaBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBookAsync();
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var book = await _bookService.GetByIdBookAsync(bookId);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookDto createBookDto)
        {
            await _bookService.CreateBookAsync(createBookDto);
            return Ok("Book created successfully !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(UpdateBookDto updateBookDto)
        {
            await _bookService.UpdateBookAsync(updateBookDto);
            return Ok("Book updated successfully !");
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            await _bookService.DeleteBookAsync(bookId);
            return Ok("Book deleted successfully !");
        }
    }
}
