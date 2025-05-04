
using System.ComponentModel.DataAnnotations;

namespace BookstoreApp.Domain.Dtos;

public class AuthorViewDto
{
    public string? FullName { get; set; }
    public List<BookViewDto>? Books { get; set; }
    [MaxLength(200)]
    public string? ShortInfo { get; set; }
}
