using BookstoreApp.Domain.Entities;

namespace BookstoreApp.Infrastructure.Interfaces;

public interface IAuthorRepository
{
    public Task<List<Author>> GetAll();
    public Task<Author> GetById(Guid AuthorId);
    public Task<Author> Update(Guid AuthorId, Author authorUpdated);
    public Task<bool> DeleteById(Guid AuthorId);
}
