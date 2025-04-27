using BookstoreApp.Domain.Entities;

namespace BookstoreApp.Infrastructure.Interfaces;


public interface IBookRepository
{
    public Task<List<Book>> GetAllAsync();  
    public Task<Book> GetByIdAsync(int Id);
    public Task<Book> GetByBookIdAsync(Guid Id);
    public Task<Book> GetByNameAsync(string Name);  
    public Task<Book> GetByAuthorAsync(string Author);
    
    public Task<bool> AddBook(Book book);
    public Task<Book> UpdateBookAsync(Book book);
    public Task<Book> DeleteBookAsync(int Id);

}
