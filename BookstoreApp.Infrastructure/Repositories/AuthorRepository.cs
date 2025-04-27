
using BookstoreApp.Domain.Entities;
using BookstoreApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookstoreApp.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BookstoreDbContext _context;
    private readonly ILogger<AuthorRepository> _logger;

    public AuthorRepository(BookstoreDbContext context, ILogger<AuthorRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
 
    public async Task<List<Author>> GetAll()
    {
        var result = await _context.Authors.ToListAsync();
        if(result is null || result.Count == 0)
        {
            _logger.LogInformation($"No records found while trying to fetch list of authors at{DateTime.UtcNow}");
            return new List<Author>();  
        }
        return result;  
    }

    public async Task<Author> GetById(Guid AuthorId)
    {
        var result = await _context.Authors.Where(author => author.AuthorId == AuthorId).FirstOrDefaultAsync();
        if (result is null)
        {
            _logger.LogInformation($"There is no record found by {AuthorId} at {DateTime.UtcNow}");
        }
        return result;
    }

    public async Task<Author> Update(Guid AuthorId, Author authorUpdated)
    {
        var authorToUpdate = await _context.Authors.Where(author => author.AuthorId == AuthorId).FirstOrDefaultAsync();
        if (authorToUpdate is null)
        {
            _logger.LogInformation($"No record found while trying to update by authorId:{AuthorId} at{DateTime.UtcNow}");    
            return new Author();
        }
        authorToUpdate.Name = authorUpdated.Name;   
        _context.Authors.Update(authorToUpdate);    
        _context.SaveChanges();

        return authorToUpdate;
    }

    public async Task<bool> DeleteById(Guid AuthorId)
    {
        var AuthorToDelete = await _context.Authors.Where(author => author.AuthorId == AuthorId).FirstOrDefaultAsync(); 
        if(AuthorToDelete is null)
        {
            _logger.LogInformation($"No record found while trying to delete author with is{AuthorId} at{DateTime.UtcNow}");
            return false;
        }

        _context.Remove(AuthorToDelete);
        _context.SaveChanges();
        return true;        
    }
}
