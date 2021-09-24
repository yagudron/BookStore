using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Exceptions;
using BookStore.BusinessLogic.Interfaces;
using BookStore.Contracts.Commands;
using BookStore.Contracts.Entities;
using BookStore.Contracts.Queries;
using BookStore.DataAccess.Interfaces;

namespace BookStore.BusinessLogic.Services.Domain
{
    //TODO: Consider adding AutoMapper. (AK)
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository repository)
        {
            _bookRepository = repository;
        }

        public List<Book> GetBooks(BookQuery query)
        {
            return _bookRepository.GetAll()
                .Where(b => b.Title.Contains(query.Title) || query.Title == null)
                .Where(b => b.Description.Contains(query.Description) || query.Description == null)
                .Where(b => b.Author.Contains(query.Author) || query.Author == null)
                .Select(MapToContract)
                .ToList();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            var model = await GetBookByIdInternal(id);
            return MapToContract(model);
        }

        public async Task<Book> CreateBookAsync(CreateBookCommand command)
        {
            var model = MapToModel(command);
            var result = await _bookRepository.AddAsync(model);
            return MapToContract(result);
        }

        public async Task<Book> UpdateBookAsync(int id, UpdateBookCommand command)
        {
            var model = await GetBookByIdInternal(id);
            model.Author = command.Author;
            model.Description = command.Description;
            model.Title = command.Title;

            var result = _bookRepository.Update(model);
            return MapToContract(result);
        }

        public async Task RemoveBookAsync(int id)
        {
            var model = await GetBookByIdInternal(id);

            await _bookRepository.RemoveAsync(model);
        }

        private static DataAccess.Models.Book MapToModel(CreateBookCommand command)
        {
            return new DataAccess.Models.Book
            {
                Author = command.Author,
                Description = command.Description,
                Title = command.Title
            };
        }

        private static Book MapToContract(DataAccess.Models.Book model)
        {
            return new Book
            {
                Id = model.Id,
                Author = model.Author,
                Description = model.Description,
                Title = model.Title
            };
        }

        private async Task<DataAccess.Models.Book> GetBookByIdInternal(int id)
        {
            var model = await _bookRepository.GetBookByIdAsync(id);
            if (model == null)
                throw new EntityNotFoundException(nameof(Book), id);

            return model;
        }
    }
}
