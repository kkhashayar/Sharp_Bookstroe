using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Domain.Dtos;

public class BookViewDto
{
    public string Title { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
}
