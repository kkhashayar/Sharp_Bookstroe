
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var georgeOrwellId = new Guid("11111111-1111-1111-1111-111111111111");
        var rowlingId = new Guid("22222222-2222-2222-2222-222222222222");

        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                
                AuthorId = georgeOrwellId,
                Name = "George Orwell"
            },
            new Author
            {
                
                AuthorId = rowlingId,
                Name = "J.K. Rowling"
            }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                BookId = new Guid("33333333-3333-3333-3333-333333333333"),
                Title = "1984",
                ISBN = "9780451524935",
                AuthorId = georgeOrwellId,
                AuthorName = "George Orwell",
                CategoryId = 1,
                Price = 15,
                StockQuantity = 100
            },
            new Book
            {
                Id = 2,
                BookId = new Guid("44444444-4444-4444-4444-444444444444"),
                Title = "Harry Potter and the Philosopher's Stone",
                ISBN = "9780747532699",
                AuthorId = rowlingId,
                AuthorName = "J.K. Rowling",
                CategoryId = 2,
                Price = 20,
                StockQuantity = 50
            }
        );


        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);
    }
}

/* Reminder
 * 
 * 
  
   dotnet ef migrations add AuthorName_In_Book --project ../BookstoreApp.Infrastructure --startup-project ../BookstoreApp.Api
  
   dotnet ef database update --project ../BookstoreApp.Infrastructure --startup-project ../BookstoreApp.Api
 * 
 */