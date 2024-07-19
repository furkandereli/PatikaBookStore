using AutoMapper;
using PatikaBookStore.DTOs.AuthorDtos;
using PatikaBookStore.DTOs.BookDtos;
using PatikaBookStore.DTOs.GenreDtos;
using PatikaBookStore.Entities;

namespace PatikaBookStore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, ResultAuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();
            CreateMap<Author, GetAuthorByIdDto>().ReverseMap();

            CreateMap<Book, ResultBookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
            CreateMap<Book, GetBookByIdDto>().ReverseMap();

            CreateMap<Genre, ResultGenreDto>().ReverseMap();
            CreateMap<Genre, CreateGenreDto>().ReverseMap();
            CreateMap<Genre, UpdateGenreDto>().ReverseMap();
            CreateMap<Genre, GetGenreByIdDto>().ReverseMap();
        }
    }
}
