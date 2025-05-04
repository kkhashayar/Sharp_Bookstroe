using BookstoreApp.Domain.Dtos;
using BookstoreApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BookstoreApp.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BookController> _logger;

    public BookController(IBookRepository bookRepository,IUnitOfWork unitOfWork ,ILogger<BookController> logger)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;


    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllBooks()
    {
        var response = await _bookRepository.GetAllAsync();
        if (response is null || response.Count == 0)
        {
            return NotFound(response);
        }
        return Ok(response);
    }


    [HttpGet("tile")]
    public async Task<IActionResult> GetByTitle(string title)
    {
        var response = await _bookRepository.GetByTitleAsync(title);
        if (response is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateBook([FromBody] BookUpdateDto bookUpdateDto)
    {
        var response = await _bookRepository.UpdateBookAsync(bookUpdateDto);    
        if(response is null)
        {
            _logger.LogInformation($"Update failed: BookId {bookUpdateDto.BookId} not found at {DateTime.UtcNow}");
            return NotFound();  
        }
        return Ok(response);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] BookCreateDto bookCreateDto)
    {
        var response = await _unitOfWork.AddBookAsync(bookCreateDto);
        if(response is not true)
        {
            _logger.LogInformation($"create failed: Book Title {bookCreateDto.Title} Could not add {DateTime.UtcNow}");
            return BadRequest(response);

        }
        return Ok(response);

    }

    [HttpDelete("book")]
    public async Task<IActionResult> Delete(Guid bookId)
    {
        var resposne = await _bookRepository.DeleteBookAsync(bookId);
        if(resposne is false)
        {
            return BadRequest(resposne);
        }

        return NoContent(); 
    }
}
