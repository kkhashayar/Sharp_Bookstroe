using BookstoreApp.Domain.Entities;

namespace BookstoreApp.Infrastructure.Interfaces;


public interface IBookRepository
{
    public Task<List<Book>> GetAllAsync();  
    public Task<Book> GetByBookIdAsync(Guid Id);
    public Task<Book> GetByAuthorIdAsync(Guid AuthorId);
    public Task<bool> AddBook(Book book);
    public Task<Book> UpdateBookAsync(Guid bookToUpdateId, Book book);
    public Task<bool> DeleteBookAsync(int Id);

}
