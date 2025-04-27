
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

    public async Task<Book> GetByAuthorIdAsync(Guid AuthorId)
    {
        var result = await _context.Books.Where(book => book.AuthorId == AuthorId).FirstOrDefaultAsync();
        if (result is null) return null; 
        return result;
    }

    public async Task<Book> GetByBookIdAsync(Guid Id)
    {
        var result = await _context.Books.Where(book => book.BookId == Id).FirstOrDefaultAsync();
        if (result is null) return null;
        return result;
    }

    /*
        public int Id { get; set; }
        public Guid BookId { get; set; }
        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int CategoryId { get; set; }
        public int? Price { get; set; }
        public int StockQuantity { get; set; }
     */
    public async Task<Book> UpdateBookAsync(Guid bookToUpdateId, Book updatedBook)
    {
        var bookToUpdate = await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookToUpdateId);
        if (bookToUpdate is null) return null;

        bookToUpdate.Title = updatedBook.Title;
        bookToUpdate.ISBN = updatedBook.ISBN;
        bookToUpdate.AuthorName = updatedBook.AuthorName;
        bookToUpdate.Price = updatedBook.Price;
        bookToUpdate.CategoryId = updatedBook.CategoryId;   
        bookToUpdate.StockQuantity = updatedBook.StockQuantity;
        bookToUpdate.Price = updatedBook.Price;

        await _context.SaveChangesAsync();
        return bookToUpdate;
    }


    public async Task<bool> AddBook(Book book)
    {
        await _context.Books.AddAsync(book);    
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBookAsync(int Id)
    {
        var bookToRemove = await _context.Books.Where(book => book.Id == Id).FirstOrDefaultAsync(); 
        if(bookToRemove is null) return false;

        _context.Remove(bookToRemove);   
        await _context.SaveChangesAsync();
        return true;   
    }
}
