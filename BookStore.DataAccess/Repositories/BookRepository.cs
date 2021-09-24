using System.Linq;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BookStoreContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {
        }

        public Book GetBookById(int id)
        {
            return GetAll().FirstOrDefault(b => b.Id == id);
        }
    }
}