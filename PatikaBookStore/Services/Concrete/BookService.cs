using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatikaBookStore.Context;
using PatikaBookStore.DTOs.BookDtos;
using PatikaBookStore.Entities;
using PatikaBookStore.Exceptions;
using PatikaBookStore.Services.Abstract;
using System.Net;

namespace PatikaBookStore.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly PatikaDbContext _context;
        private readonly IMapper _mapper;

        public BookService(PatikaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateBookAsync(CreateBookDto createBookDto)
        {
            var book = _mapper.Map<Book>(createBookDto);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
                throw new NotFoundException($"Author with ID {bookId} not found.");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultBookDto>> GetAllBookAsync()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<List<ResultBookDto>>(books);
        }

        public async Task<GetBookByIdDto> GetByIdBookAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
                throw new NotFoundException($"Author with ID {bookId} not found.");

            return _mapper.Map<GetBookByIdDto>(book);
        }

        public async Task UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            var bookExist = await _context.Books.FindAsync(updateBookDto.Id);

            if (bookExist == null)
                throw new NotFoundException($"Author with ID {updateBookDto.Id} not found.");

            _mapper.Map(updateBookDto, bookExist);
            await _context.SaveChangesAsync();
        }
    }
}
