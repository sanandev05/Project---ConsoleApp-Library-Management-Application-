using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.DTOs;
using Project___ConsoleApp__Library_Management_Application_.DTOs.AuthorDto;
using Project___ConsoleApp__Library_Management_Application_.Exceptions.AuthorExceptions;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Implementations;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces;
using Project___ConsoleApp__Library_Management_Application_.Services.Interfaces;

namespace Project___ConsoleApp__Library_Management_Application_.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        IAuthorRepository authorRepository = new AuthorRepository();
        AuthorRepository authorRepositoryAllFuncs = new AuthorRepository();
        IBookRepository bookRepository = new BookRepository();
        public void Create(AuthorCreateDto dto)
        {
            if (dto == null) throw new AuthorNullException("Author Create DTO is Null ");
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new AuthorNameIsNullOrWhiteSpaceException("Author Name is Null or White Space ");

            Author author = new Author()
            {
                Name = dto.Name,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                IsDeleted = false
            };
            authorRepository.Create(author);
            authorRepository.SaveChanges();
        }

        public void SoftDeleteAuthor(int id)
        {
            foreach (var authorBooks in authorRepository.GetByIdWithInclude(id).Books)
            {
                Book book = authorBooks;
                bookRepository.Delete(book);
            }
            Author author = authorRepository.GetByIdWithInclude(id);
            if (author is null) throw new AuthorNotFoundException("Author Not Found");
            authorRepositoryAllFuncs.SoftDeleteAuthor(id);
            authorRepositoryAllFuncs.SaveChanges();

           
           
        }
        
        public List<AuthorGetDto> GetAll()
        {
            var get = authorRepository.GetAllWithInclude().Where(x => !x.IsDeleted);
            var data = new List<AuthorGetDto>();
            return data = get.Select(x => new AuthorGetDto()
            {
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                Id = x.Id,
                IsDeleted = x.IsDeleted,
                UpdatedAt = x.UpdatedAt,
                Books = x.Books,
            }).ToList();
        }

        public AuthorGetDto GetById(int id)
        {
            var get = authorRepository.GetByIdWithInclude(id);
            if (get is not null)
            {
                if (!get.IsDeleted)
                {
                    AuthorGetDto dto = new AuthorGetDto()
                    {
                        Name = get.Name,
                        CreatedAt = get.CreatedAt,
                        Id = id,
                        IsDeleted = get.IsDeleted,
                        UpdatedAt = get.UpdatedAt
                    };
                    return dto;
                }
                else return null;
            }
            else
            {
                return null;

            }
        }

        public void Update(int id, AuthorUpdateDto dto)
        {

            if (dto == null) throw new AuthorNullException("Author Create DTO is Null ");
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new AuthorNameIsNullOrWhiteSpaceException("Author Name is Null or White Space ");
            if (!dto.IsDeleted)
            {
                var author = authorRepository.GetByIdWithInclude(id);
                if (author is null) throw new NullReferenceException("Not Found Author");
                author.Name = dto.Name;
                author.UpdatedAt = dto.UpdatedAt;

                authorRepository.Commit(author);
                authorRepository.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("Not Found Author");
            }
        }
    }
}
