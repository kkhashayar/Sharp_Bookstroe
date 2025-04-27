
using BookstoreApp.Domain.Entities;
using BookstoreApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookstoreApp.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookstoreDbContext _context;
    private readonly ILogger<BookRepository> _logger;

    public BookRepository(BookstoreDbContext context, ILogger<BookRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        var result = await _context.Books.ToListAsync();
        if(result is null || result.Count == 0) return new List<Book>();    
        return result;
    }

    public Task<Book> GetByAuthorAsync(string Author)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByBookIdAsync(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByNameAsync(string Name)
    {
        throw new NotImplementedException();
    }
    public Task<bool> AddBook(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<Book> UpdateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<Book> DeleteBookAsync(int Id)
    {
        throw new NotImplementedException();
    }
}
