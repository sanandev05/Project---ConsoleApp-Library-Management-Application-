using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.Data;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces;

namespace Project___ConsoleApp__Library_Management_Application_.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        AppDbContext context = new AppDbContext();
        public int Commit()
        => context.SaveChanges();

        public void Create(T entity)
        => context.Set<T>().Add(entity);

        public void Delete(T entity)
        => context.Set<T>().Remove(entity);

        public List<T> GetAll()
        => context.Set<T>().ToList();

        public T GetById(int id)
        => context.Set<T>().FirstOrDefault(x => x.Id == id);

      
    }
}
