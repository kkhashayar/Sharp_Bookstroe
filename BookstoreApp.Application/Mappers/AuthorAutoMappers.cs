using AutoMapper;
using BookstoreApp.Domain.Dtos;
using BookstoreApp.Domain.Entities;

namespace BookstoreApp.Application.Mappers;

public class AuthorAutoMappers: Profile
{
    public AuthorAutoMappers()
    {
        CreateMap<Author, AuthorViewDto>().ReverseMap();    
    }
}
