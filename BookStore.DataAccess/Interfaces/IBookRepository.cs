using System.Threading.Tasks;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookByIdAsync(int id);
    }
}
