using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.DTOs.AuthorDto;

namespace Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        public void Create(Author entity);
        public void Delete(Author entity);
        public Author GetByIdWithInclude(int id);
        public List<Author> GetAllWithInclude();
        public int Commit(Author author);
        int SaveChanges();

    }
}
