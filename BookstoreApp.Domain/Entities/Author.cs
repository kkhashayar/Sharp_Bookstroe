namespace BookstoreApp.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    public Guid AuthorId { get; set; }
    public string? Name { get; set; }
}
