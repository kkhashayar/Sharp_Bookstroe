

using BookstoreApp.Domain.Dtos;

namespace BookstoreApp.Infrastructure.Interfaces;
public interface IUnitOfWork
{
    IBookRepository BookRepository { get; }
    IAuthorRepository AuthorRepository { get; }

    public Task<bool> AddBookAsync(BookCreateDto bookCreateDto);

    // In case of creating author it should return 2 records changed
    Task<int> SaveChangeAsync(); 
}
