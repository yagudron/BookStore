
using System;
using BookStore.BusinessLogic.Interfaces;
using BookStore.BusinessLogic.Services.Domain;
using BookStore.DataAccess;
using BookStore.DataAccess.Interfaces;
using BookStore.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BookStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<BookStoreContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureServices((_, services) =>
            {
                services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookStore;Trusted_Connection=True;MultipleActiveResultSets=true"));

                services.AddTransient(typeof(IRepository<>), typeof(RepositoryBase<>));
                services.AddTransient<IBookRepository, BookRepository>();

                services.AddTransient<IBookService, BookService>();
            });
    }
}
