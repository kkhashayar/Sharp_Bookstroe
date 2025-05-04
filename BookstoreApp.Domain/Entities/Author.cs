using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookstoreApp.Domain.Entities;

public class Author
{
    public Guid AuthorId { get; set; }
    public string? Name { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();

    public string? ShortInfo { get; set; }
}
