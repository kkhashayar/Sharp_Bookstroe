namespace BookstoreApp.Domain.Dtos;


public class BookUpdateDto
{
    public string Title { get; set; }
    public string? ISBN { get; set; }
    public Guid AuthorId { get; set; }
    public string Category { get; set; }
    public int? Price { get; set; }
    public int StockQuantity { get; set; }

}
