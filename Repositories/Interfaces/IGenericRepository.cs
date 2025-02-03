using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        public void Create(T entity);
        public void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
        int Commit(T entity);
        int SaveChanges();

    }
}
