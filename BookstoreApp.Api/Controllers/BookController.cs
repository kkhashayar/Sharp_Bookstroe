using BookstoreApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BookstoreApp.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly ILogger<BookController> _logger;

    public BookController(IBookRepository bookRepository, ILogger<BookController> logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;


    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllBooks()
    {
        var response = await _bookRepository.GetAllAsync(); 
        if(response is null || response.Count == 0)
        {
            return NotFound(response);
        }
        return Ok(response);    
    }


    [HttpGet()]
    public async Task<IActionResult> GetByName(string title)
    {
        var response = await _bookRepository.GetByTitleAsync(title);
        if(response is null)
        {
            return NotFound(response);  
        }
        return Ok(response);    
    }
}
