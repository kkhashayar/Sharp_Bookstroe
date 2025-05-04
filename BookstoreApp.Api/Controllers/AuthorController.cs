using BookstoreApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApp.Api.Controllers;

[ApiController]
// [Route("api/[controller]")]

[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorRepository _authorRepository;
    private readonly ILogger<AuthorController> _logger;

    public AuthorController(IAuthorRepository authorRepository, ILogger<AuthorController> logger)
    {
        _authorRepository = authorRepository;
        _logger = logger;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _authorRepository.GetAllAsync();       
        if(response is null || response.Count == 0)
        {
            return NotFound();
        }
        return Ok(response);    
    }

    [HttpGet("author")]
    public async Task<IActionResult> GetAuthor(string Name)
    {
        var response = await _authorRepository.GetByNameAsync(Name);
        if(response is null)
        {
            return NotFound(); 
        }
        return Ok(response);
    }
}
