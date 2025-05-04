using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Domain.Dtos;


public class BookUpdateDto
{
    // For showcase and simplicity, I removed some of the properties. 
    
    public Guid BookId { get; set; }
    [Required]
    public string Title { get; set; }
    public string ISBN { get; set; }
    //public Guid AuthorId { get; set; }
    public string AuthorName { get; set; }
    public int CategoryId { get; set; }

    //public string Category { get; set; }
    [Required]
    public int Price { get; set; }
    public int StockQuantity { get; set; }

}
