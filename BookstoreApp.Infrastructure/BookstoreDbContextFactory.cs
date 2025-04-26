
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BookstoreApp.Infrastructure;

public class BookstoreDbContextFactory: IDesignTimeDbContextFactory<BookstoreDbContext>
{
    public BookstoreDbContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<BookstoreDbContext>();
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionBuilder.UseSqlServer(connectionString);

        return new BookstoreDbContext(optionBuilder.Options);   
    }
}

