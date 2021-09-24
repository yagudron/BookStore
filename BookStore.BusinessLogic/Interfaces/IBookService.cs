using System.Collections.Generic;
using BookStore.Contracts.Commands;
using BookStore.Contracts.Entities;
using BookStore.Contracts.Queries;

namespace BookStore.BusinessLogic.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks(BookQuery query = null);
        Book GetBook(int bookId);
        Book CreateBook(CreateBookCommand command);
        Book UpdateBook(int id, UpdateBookCommand command);
        void RemoveBook(int id);
    }
}
