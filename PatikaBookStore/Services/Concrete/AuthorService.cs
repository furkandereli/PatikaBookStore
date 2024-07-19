using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatikaBookStore.Context;
using PatikaBookStore.DTOs.AuthorDtos;
using PatikaBookStore.Entities;
using PatikaBookStore.Exceptions;
using PatikaBookStore.Services.Abstract;

namespace PatikaBookStore.Services.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly PatikaDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(PatikaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var author = _mapper.Map<Author>(createAuthorDto);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);

            if (author == null)
                throw new NotFoundException($"Author with ID {authorId} not found.");

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultAuthorDto>> GetAllAuthorAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            return _mapper.Map<List<ResultAuthorDto>>(authors);
        }

        public async Task<GetAuthorByIdDto> GetByIdAuthorAsync(int authorId)
        {
            var author = await _context.Authors.FindAsync(authorId);

            if (author == null)
                throw new NotFoundException($"Author with ID {authorId} not found.");

            return _mapper.Map<GetAuthorByIdDto>(author);
        }

        public async Task UpdateAuthorAsync(UpdateAuthorDto updateAuthorDto)
        {
            var authorExist = await _context.Authors.FindAsync(updateAuthorDto.Id);

            if (authorExist == null)
                throw new NotFoundException($"Author with ID {updateAuthorDto.Id} not found.");

            _mapper.Map(updateAuthorDto, authorExist);
            await _context.SaveChangesAsync();
        }
    }
}
