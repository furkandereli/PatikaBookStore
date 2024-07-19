using Microsoft.AspNetCore.Mvc;
using PatikaBookStore.DTOs.GenreDtos;
using PatikaBookStore.Services.Abstract;

namespace PatikaGenreStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenreAsync();
            return Ok(genres);
        }

        [HttpGet("{genreId}")]
        public async Task<IActionResult> GetGenreById(int genreId)
        {
            var genre = await _genreService.GetByIdGenreAsync(genreId);
            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreDto createGenreDto)
        {
            await _genreService.CreateGenreAsync(createGenreDto);
            return Ok("Genre created successfully !");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre(UpdateGenreDto updateGenreDto)
        {
            await _genreService.UpdateGenreAsync(updateGenreDto);
            return Ok("Genre updated successfully !");
        }

        [HttpDelete("{genreId}")]
        public async Task<IActionResult> DeleteGenre(int genreId)
        {
            await _genreService.DeleteGenreAsync(genreId);
            return Ok("Genre deleted successfully !");
        }
    }
}
