using AutoMapper;
using BookstoreApp.Domain.Dtos;
using BookstoreApp.Domain.Entities;


namespace BookstoreApp.Application.Mappers;

public class BookAutoMappers : Profile 
{
    public BookAutoMappers()
    {
        CreateMap<Book, BookCreateDto>().ReverseMap();  
        CreateMap<Book, BookUpdateDto>().ReverseMap();
        CreateMap<Book, BookViewDto>().ReverseMap();
    }
}
