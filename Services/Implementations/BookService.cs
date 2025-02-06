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
        IAuthorRepository authorRepository = new AuthorRepository();
        BookRepository bookRepoAllFuncs= new BookRepository();
        public void Create(int authorId,BookCreateDto entity)
        {
            if (entity == null) throw new BookNullException("Book is Null ");

            if (string.IsNullOrWhiteSpace(entity.Title)
                || string.IsNullOrWhiteSpace(entity.Description)) throw new BookTitleOrDescriptionIsNullOrWhiteSpaceException();

            if (entity.PublishYear < 1000) throw new BookPublishedYearNotTrueException("Book Publish Year can not be below than 1000");

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

           bookRepoAllFuncs.CreateWithAuthorID(authorId,book);
            

        }

        public void Delete(int id)
        {
            Book book = bookRepository.GetByIdWithInclude(id);
            if (book is null) throw new AuthorNotFoundException("Book Not Found");
            bookRepository.Delete(book);
            bookRepository.SaveChanges();

        }

        public List<BookGetDto> GetAll()
        {
            var get = bookRepository.GetAllWithInclude().Where(x => !x.IsDeleted);
            var data = new List<BookGetDto>();
            return data = get.Select(x => new BookGetDto()
            {
                Title = x.Title,
                CreatedAt = x.CreatedAt,
                Id = x.Id,
                IsDeleted = x.IsDeleted,
                UpdatedAt = x.UpdatedAt,
                Description = x.Description,
                Authors =x.Authors,
                PublishYear = x.PublishedYear,
            }).ToList();
        }

        public BookGetDto GetById(int id)
        {
            var get = bookRepository.GetByIdWithInclude(id);
            if (!get.IsDeleted)
            {
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
            else return null;
        }

        public void Update(int id, BookUpdateDto dto)
        {
            BookRepository bookRepository = new BookRepository();
            if (dto == null) throw new BookNullException("Book is Null ");

            if (string.IsNullOrWhiteSpace(dto.Title)
                || string.IsNullOrWhiteSpace(dto.Description)) throw new BookTitleOrDescriptionIsNullOrWhiteSpaceException();

            if (dto.PublishYear < 1000) throw new BookPublishedYearNotTrueException("Book Publish Year is not True");

            if (!dto.IsDeleted)
            {
                Book book = bookRepository.GetByIdWithInclude(id);
                book.Title = dto.Title;
                book.Description = dto.Description;
                book.UpdatedAt = dto.UpdatedAt;
                book.PublishedYear = dto.PublishYear;

                bookRepository.Commit(book);
                bookRepository.SaveChanges();
            }
            else throw new NullReferenceException("Not Found Book");
        }
        
        public int MostLoanedBookID()
        {
            ILoanItemRepository loanItemRepository = new LoanItemRepository();
           var mostBorrowedBook= loanItemRepository.GetAllWithInclude()
                              .GroupBy(x => x.BookId)
                              .OrderByDescending(y => y.Count())
                              .Select(g => new { BookId = g.Key, Count = g.Count() })
                              .FirstOrDefault();
            return mostBorrowedBook.BookId;
  
        }
        
    }
}
