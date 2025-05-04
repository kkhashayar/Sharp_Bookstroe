
using AutoMapper;
using BookstoreApp.Domain.Dtos;
using BookstoreApp.Domain.Entities;
using BookstoreApp.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace BookstoreApp.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookstoreDbContext _context;
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(BookstoreDbContext context, IBookRepository bookRepository, 
           IAuthorRepository authorRepository, IMapper mapper, ILogger<UnitOfWork> logger)
    {
        _context = context;
        _bookRepository = bookRepository;   
        _authorRepository = authorRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public IBookRepository BookRepository { get; }
    public IAuthorRepository AuthorRepository { get; }

    public async Task<bool> AddBookAsync(BookCreateDto bookCreateDto)
    {
        var bookEntity = _mapper.Map<Book>(bookCreateDto);     
        var author = await _authorRepository.GetByNameAsync(bookEntity.AuthorName); 
        if(author is null)
        {
            Guid authorId = Guid.NewGuid();
            Author newAuthor = new Author
            {
                Name = bookEntity.AuthorName,
                AuthorId = authorId,    
            };
            var authoraddResponse = await _authorRepository.AddAuthorAsync(newAuthor);  
           if(authoraddResponse == 1)
            {
                bookEntity.AuthorId = authorId; 
                var newBookId = Guid.NewGuid();    
                bookEntity.BookId = newBookId; 
                var responseNewBookAdd = await _bookRepository.AddBookAsync(bookEntity);   

                if(responseNewBookAdd == 1) return true;   
            }
        }

        bookEntity.AuthorId = author.AuthorId;
        var bookId = Guid.NewGuid();
        bookEntity.BookId = bookId;
        var responseBookAdd = await _bookRepository.AddBookAsync(bookEntity);

        if (responseBookAdd == 1) return true;
        return false;
    }

    public async Task<int> SaveChangeAsync()
    {
        return await _context.SaveChangesAsync();   
    }
}
