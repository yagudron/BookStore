using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBookById(int id);
    }
}
