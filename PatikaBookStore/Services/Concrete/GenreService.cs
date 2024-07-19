using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatikaBookStore.Context;
using PatikaBookStore.DTOs.GenreDtos;
using PatikaBookStore.Entities;
using PatikaBookStore.Exceptions;
using PatikaBookStore.Services.Abstract;

namespace PatikaGenreStore.Services.Concrete
{
    public class GenreService : IGenreService
    {
        private readonly PatikaDbContext _context;
        private readonly IMapper _mapper;

        public GenreService(PatikaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateGenreAsync(CreateGenreDto createGenreDto)
        {
            var genre = _mapper.Map<Genre>(createGenreDto);
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenreAsync(int genreId)
        {
            var genre = await _context.Genres.FindAsync(genreId);

            if (genre == null)
                throw new NotFoundException($"Author with ID {genreId} not found.");

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultGenreDto>> GetAllGenreAsync()
        {
            var genres = await _context.Genres.ToListAsync();
            return _mapper.Map<List<ResultGenreDto>>(genres);
        }

        public async Task<GetGenreByIdDto> GetByIdGenreAsync(int genreId)
        {
            var genre = await _context.Genres.FindAsync(genreId);

            if (genre == null)
                throw new NotFoundException($"Author with ID {genreId} not found.");

            return _mapper.Map<GetGenreByIdDto>(genre);
        }

        public async Task UpdateGenreAsync(UpdateGenreDto updateGenreDto)
        {
            var genreExist = await _context.Genres.FindAsync(updateGenreDto.Id);

            if (genreExist == null)
                throw new NotFoundException($"Author with ID {updateGenreDto.Id} not found.");

            _mapper.Map(updateGenreDto, genreExist);
            await _context.SaveChangesAsync();
        }
    }
}
