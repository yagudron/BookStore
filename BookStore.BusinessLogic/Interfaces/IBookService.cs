using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Contracts.Commands;
using BookStore.Contracts.Entities;
using BookStore.Contracts.Queries;

namespace BookStore.BusinessLogic.Interfaces
{
    public interface IBookService
    {
        List<Book> GetBooks(BookQuery query);
        Task<Book> GetBookAsync(int id);
        Task<Book> CreateBookAsync(CreateBookCommand command);
        Task<Book> UpdateBookAsync(int id, UpdateBookCommand command);
        Task RemoveBookAsync(int id);
    }
}
