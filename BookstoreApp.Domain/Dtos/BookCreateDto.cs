using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Domain.Dtos;

public class BookCreateDto
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string AuthorName { get; set; }
    public int CategoryId { get; set; }
    public int? Price { get; set; }
    public int StockQuantity { get; set; }
}
