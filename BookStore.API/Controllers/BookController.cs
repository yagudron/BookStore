using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Interfaces;
using BookStore.Contracts.Commands;
using BookStore.Contracts.Entities;
using BookStore.Contracts.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.API.Controllers
{
    [ApiController, Route("api")]
    //TODO: Add proper exception handling. (AK)
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }
        
        /// <summary>
        /// Get all books.
        /// </summary>
        [HttpGet, Route("books")]
        public IEnumerable<Book> GetBooks([FromBody] BookQuery query)
        {
            return _bookService.GetBooks(query);
        }

        /// <summary>
        /// Add new book.
        /// </summary>
        /// <param name="id"></param>
        [HttpPost, Route("books")]
        public async Task<Book> CreateBookAsync([FromBody] CreateBookCommand command)
        {
            return await _bookService.CreateBookAsync(command);
        }

        /// <summary>
        /// Get specific book by Id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet, Route("books/{id}")]
        public Task<Book> GetBookAsync([FromRoute] int id)
        {
            return _bookService.GetBookAsync(id);
        }

        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="id"></param>
        [HttpPut, Route("book/{id}")]
        public async Task<Book> UpdateBookAsync([FromRoute] int id, [FromBody] UpdateBookCommand command)
        {
            return await _bookService.UpdateBookAsync(id, command);
        }

        /// <summary>
        /// Delete the book.
        /// </summary>
        [HttpDelete, Route("book/{id}")]
        public async Task DeleteBookAsync([FromRoute] int id)
        {
            await _bookService.RemoveBookAsync(id);
        }
    }
}
