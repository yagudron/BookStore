using System;
using System.Threading.Tasks;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(BookStoreContext repositoryPatternDemoContext) : base(repositoryPatternDemoContext)
        {
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}