namespace BookstoreApp.Domain.Entities;

public class Book
{
    public int Id { get; set; }
    public Guid BookId { get; set; }
    public string? Title { get; set; }
    public string? ISBN { get; set; }
    public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }
    public int CategoryId { get; set; }
    public int? Price { get; set; }
    public int StockQuantity { get; set; }

    public Author? Author { get; set; }  

}
