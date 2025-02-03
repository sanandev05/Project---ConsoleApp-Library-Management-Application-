using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.DTOs.AuthorDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BookDto;
using Project___ConsoleApp__Library_Management_Application_.Exceptions.AuthorExceptions;
using Project___ConsoleApp__Library_Management_Application_.Exceptions.BookExceptions;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Implementations;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces;
using Project___ConsoleApp__Library_Management_Application_.Services.Interfaces;

namespace Project___ConsoleApp__Library_Management_Application_.Services.Implementations
{
    public class BookService : IBookService
    {
            IBookRepository bookRepository = new BookRepository();
        public void Create(BookCreateDto entity)
        {
            if (entity == null) throw new BookNullException("Book is Null ");
            
            if (string.IsNullOrWhiteSpace(entity.Title)
                || string.IsNullOrWhiteSpace(entity.Description)) throw new BookTitleOrDescriptionIsNullOrWhiteSpaceException();
            
            if(entity.PublishYear<1000) throw new BookPublishedYearNotTrueException("Book Publish Year is not True");

            Book book = new Book()
            {
                Title = entity.Title,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,                
                PublishedYear = entity.PublishYear
                
            };
            book.Authors = entity.Authors;
            book.IsDeleted = entity.IsDeleted;
            bookRepository.Create(book);
        }

        public void Delete(int id)
        {
            Book book =bookRepository.GetByIdWithInclude(id);
            if (book is null) throw new AuthorNotFoundException("Book Not Found");
            bookRepository.Delete(book);
        }

        public List<BookGetDto> GetAll()
        {
            var get = bookRepository.GetAllWithInclude();
            var data = new List<BookGetDto>();
            return data = get.Select(x => new BookGetDto()
            {
                Title = x.Title,
                CreatedAt = x.CreatedAt,
                Id = x.Id,
                IsDeleted = x.IsDeleted,
                UpdatedAt = x.UpdatedAt,
                Description = x.Description,
                Authors = x.Authors,
                PublishYear = x.PublishedYear,
            }).ToList();
        }

        public BookGetDto GetById(int id)
        {
            var get = bookRepository.GetByIdWithInclude(id);
            BookGetDto dto = new BookGetDto()
            {
                Title = get.Title,
                CreatedAt = get.CreatedAt,
                Id = id,
                IsDeleted = get.IsDeleted,
                UpdatedAt = get.UpdatedAt,
                Description = get.Description,
                Authors = get.Authors,
                PublishYear = get.PublishedYear,
            };
            return dto;
        }
    }
}
