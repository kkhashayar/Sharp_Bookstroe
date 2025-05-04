using BookstoreApp.Domain.Dtos;
using BookstoreApp.Domain.Entities;

namespace BookstoreApp.Infrastructure.Interfaces;

public interface IAuthorRepository
{
    public Task<List<AuthorViewDto>> GetAllAsync();
    public Task<AuthorViewDto> GetByIdAsync(Guid AuthorId);
    public Task<Author> GetByNameAsync(string Name); 
    public Task<int> AddAuthorAsync(Author author);    
    public Task<Author> UpdateAsync(Guid AuthorId, Author authorUpdated);
    public Task<bool> DeleteById(Guid AuthorId);
}
