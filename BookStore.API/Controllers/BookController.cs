using System.Collections.Generic;
using BookStore.BusinessLogic.Interfaces;
using BookStore.Contracts.Commands;
using BookStore.Contracts.Entities;
using BookStore.Contracts.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api")]
    //TODO: Add base contract and proper exception handling. (AK)
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
        public Book CreateBook([FromBody] CreateBookCommand command)
        {
            return _bookService.CreateBook(command);
        }

        /// <summary>
        /// Get specific book by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("books/{id}")]
        public Book GetBook([FromRoute] int id)
        {
            return _bookService.GetBook(id);
        }

        /// <summary>
        /// Update book.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut, Route("book/{id}")]
        public Book UpdateBook([FromRoute] int id, [FromBody] UpdateBookCommand command)
        {
            return _bookService.UpdateBook(id, command);
        }

        /// <summary>
        /// Delete the book.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete, Route("book/{id}")]
        public void DeleteBook([FromRoute] int id)
        {
            _bookService.RemoveBook(id);
        }
    }
}
