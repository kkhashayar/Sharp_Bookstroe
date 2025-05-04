using AutoMapper;
using BookstoreApp.Application.Mappers;
using BookstoreApp.Domain.Dtos;
using BookstoreApp.Domain.Entities;
using BookstoreApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookstoreApp.Infrastructure.Repositories;

public class BookRepository : IBookRepository 
{
    private readonly BookstoreDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<BookRepository> _logger;

    public BookRepository(BookstoreDbContext context, IMapper mapper ,ILogger<BookRepository> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<Book>> GetAllAsync()
    {
        var result = await _context.Books.ToListAsync();
        if (result is null || result.Count == 0)
        {
            _logger.LogInformation($"No record found while trying to fetch List of books at{DateTime.UtcNow}");
            return new List<Book>();
        }


        return result;
    }
    public async Task<Book> GetByTitleAsync(string Title)
    {
        var result = await _context.Books.Where(book => book.Title == Title).FirstOrDefaultAsync();
        if (result is null)
        {
            _logger.LogInformation($"No record found while trying to fetch a book by title:{Title} at:{DateTime.UtcNow}");
            return result; // Which is null
        }
        return result;
    }
    public async Task<Book> GetByAuthorIdAsync(Guid AuthorId)
    {
        var result = await _context.Books.Where(book => book.AuthorId == AuthorId).FirstOrDefaultAsync();
        if (result is null)
        {
            _logger.LogInformation($"No record while trying to fetch Book by authorId at {DateTime.UtcNow}");
            return null;
        }
        return result;
    }

    public async Task<Book> GetByBookIdAsync(Guid Id)
    {
        var result = await _context.Books.Where(book => book.BookId == Id).FirstOrDefaultAsync();
        if (result is null)
        {
            _logger.LogInformation($"No record while trying to fetch Book by Book Id at {DateTime.UtcNow}");
            return null;
        }
        return result;
    }
    public async Task<int> AddBookAsync(Book bookEntity)
    {
        var response = await _context.AddAsync(bookEntity);
        var saveResponse = await  _context.SaveChangesAsync();

        if (saveResponse != 1)
        {
            _logger.LogError($"Something went wrong while trying to add new item into book repo at:{DateTime.UtcNow}");
            return 0;
        }
        return saveResponse;

    }
    public async Task<Book> UpdateBookAsync(BookUpdateDto updateDto)
    {
        var bookToUpdate = await _context.Books.FirstOrDefaultAsync(b => b.BookId == updateDto.BookId);
        if (bookToUpdate is null)
        {
            _logger.LogInformation($"{updateDto.BookId} not found at {DateTime.UtcNow}");
            return null;
        }

        // Sending to private method
        UpdateBookValues(updateDto, bookToUpdate);

        var saveResponse = await _context.SaveChangesAsync();
        if(saveResponse != 1)
        {
            _logger.LogError($"Something went wrong in process of updating the record with id:{updateDto.BookId}");
            return null;
        }
        return bookToUpdate;
    }


    private void UpdateBookValues(BookUpdateDto updateDto, Book? bookToUpdate)
    {
        bookToUpdate.Title = updateDto.Title;
        bookToUpdate.ISBN = updateDto.ISBN;
        bookToUpdate.AuthorName = updateDto.AuthorName;
        bookToUpdate.Price = updateDto.Price;
        bookToUpdate.CategoryId = updateDto.CategoryId;
        bookToUpdate.StockQuantity = updateDto.StockQuantity;
        bookToUpdate.Price = updateDto.Price;
        _context.Books.Update(bookToUpdate);
    }
    public async Task<bool> DeleteBookAsync(Guid bookId)
    {
        var bookToRemove = await _context.Books.Where(book => book.BookId == bookId).FirstOrDefaultAsync();
        if (bookToRemove is null)
        {
            _logger.LogInformation($"{bookToRemove} Not found at {DateTime.UtcNow}");
            return false;
        }
        _context.Remove(bookToRemove);
        await _context.SaveChangesAsync();
        return true;
    }

   
}
