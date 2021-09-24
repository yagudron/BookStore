using System.Linq;
using BookStore.DataAccess.Models;

namespace BookStore.DataAccess.Utilities
{
    public static class DatabaseInitializer
    {
        public static void Initialize(BookStoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
                return;

            context.Books.AddRange(
                new Book
                {
                    Id = 1,
                    Title = "Name A",
                    Author = "Dummy A",
                    Description = "Description A"
                },
                new Book
                {
                    Id = 2,
                    Title = "Name A",
                    Author = "Dummy A",
                    Description = "Description A"
                },
                new Book
                {
                    Id = 3,
                    Title = "Name C",
                    Author = "Dummy C",
                    Description = "Description C"
                },
                new Book
                {
                    Id = 4,
                    Title = "Name D",
                    Author = "Dummy D",
                    Description = "Description D"
                });

            context.SaveChanges();
        }
    }
}
