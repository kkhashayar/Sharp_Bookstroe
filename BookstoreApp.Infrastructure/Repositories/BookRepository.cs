
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

    
    
}
