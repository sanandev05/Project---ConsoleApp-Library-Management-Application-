using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project___ConsoleApp__Library_Management_Application_.Data;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces;

namespace Project___ConsoleApp__Library_Management_Application_.Repositories.Implementations
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        AppDbContext _dbContext = new AppDbContext();
        public Book GetByIdWithInclude(int id)
        {
            Book author = _dbContext.Books.Include(x => x.Authors).FirstOrDefault(x => x.Id == id);
            return author;
        }
        public List<Book> GetAllWithInclude()
        {
            return _dbContext.Books.Include(x => x.Authors).ToList();
        }
        public void CreateWithAuthorID(int authorId, Book entity)
        {
            Book book = new Book()
            {
                CreatedAt = DateTime.Now,
                Description = entity.Description,
                Title = entity.Title,
                IsDeleted = false,
                PublishedYear = entity.PublishedYear,
                UpdatedAt = DateTime.Now,
                Authors = new List<Author>() { _dbContext.Authors.FirstOrDefault(x => x.Id == authorId) },
            };
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }
        public void SoftDeleteBook(int id)
        {
            var del = _dbContext.Books.Include(x=>x.Authors).FirstOrDefault(x => x.Id == id);
            del.IsDeleted = true;
            del.Authors.Clear();
            _dbContext.Update(del);
            _dbContext.SaveChanges();
        }

    }
}
