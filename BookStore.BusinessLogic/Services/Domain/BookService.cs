using System.Collections.Generic;
using System.Linq;
using BookStore.BusinessLogic.Interfaces;
using BookStore.Contracts.Commands;
using BookStore.Contracts.Entities;
using BookStore.Contracts.Queries;
using BookStore.DataAccess.Interfaces;

namespace BookStore.BusinessLogic.Services.Domain
{
    //TODO: Use asnyc methods of the repository, propagete that to controller level.
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
                .Select(MapToContract).ToList();
        }

        public Book GetBook(int bookId)
        {
            var model = _bookRepository.GetBookById(bookId);
            return MapToContract(model);
        }

        public Book CreateBook(CreateBookCommand command)
        {
            var model = MapToModel(command);
            var result = _bookRepository.Add(model);
            return MapToContract(result);
        }

        public Book UpdateBook(int id, UpdateBookCommand command)
        {
            var model = _bookRepository.GetBookById(id);
            model.Author = command.Author;
            model.Description = command.Description;
            model.Title = command.Title;

            var result = _bookRepository.Update(model);
            return MapToContract(result);
        }

        public void RemoveBook(int id)
        {
            var model = _bookRepository.GetBookById(id);
            _bookRepository.Remove(model);
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
    }
}
