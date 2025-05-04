using BookstoreApp.Domain.Dtos;
using BookstoreApp.Domain.Entities;

namespace BookstoreApp.Infrastructure.Interfaces;


public interface IBookRepository
{
    public Task<List<Book>> GetAllAsync();
    public Task<Book> GetByTitleAsync(string Title);
    public Task<Book> GetByBookIdAsync(Guid Id);
    public Task<Book> GetByAuthorIdAsync(Guid AuthorId);
    public Task<int> AddBookAsync(Book bookEntity); 
    public Task<Book> UpdateBookAsync(BookUpdateDto updateDto);
    public Task<bool> DeleteBookAsync(Guid bookId);

}
