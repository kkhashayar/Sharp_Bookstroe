
using BookstoreApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookstoreApp.Infrastructure;

public class BookstoreDbContext : DbContext
{
    public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}

/* Reminder
 * 
 * 
  
   dotnet ef migrations add AuthorName_In_Book --project ../BookstoreApp.Infrastructure --startup-project ../BookstoreApp.Api
  
   dotnet ef database update --project ../BookstoreApp.Infrastructure --startup-project ../BookstoreApp.Api
 * 
 */