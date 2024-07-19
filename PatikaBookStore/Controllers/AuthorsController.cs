using Microsoft.AspNetCore.Mvc;
using PatikaBookStore.DTOs.AuthorDtos;
using PatikaBookStore.Services.Abstract;

namespace PatikaBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorAsync();
            return Ok(authors);
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetAuthorById(int authorId)
        {
            var author = await _authorService.GetByIdAuthorAsync(authorId);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            await _authorService.CreateAuthorAsync(createAuthorDto);
            return Ok("Author created successfully !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            await _authorService.UpdateAuthorAsync(updateAuthorDto);
            return Ok("Author updated successfully !");
        }

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            await _authorService.DeleteAuthorAsync(authorId);
            return Ok("Author deleted successfully !");
        }
    }
}
