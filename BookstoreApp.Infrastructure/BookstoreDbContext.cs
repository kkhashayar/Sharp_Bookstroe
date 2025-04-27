
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
}

/* Reminder
 * 
 * 
   dotnet ef migrations add GuidId_In_Book_And_Author --project ../BookstoreApp.Infrastructure --startup-project .
   dotnet ef database update --project ../BookstoreApp.Infrastructure --startup-project .
 * 
 */