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
    public class BookRepository : GenericRepository<Book>,IBookRepository
    {
        AppDbContext _dbContext = new AppDbContext();
        public Book GetByIdWithInclude(int id)
        {
            Book author = _dbContext.Books.Include(x=>x.Authors).FirstOrDefault(x=>x.Id == id);
            return author;
        }
        public List<Book> GetAllWithInclude()
        {
            return _dbContext.Books.Include(x => x.Authors).ToList();
        }
        

    }
}
