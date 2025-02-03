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
        AppDbContext context ;
        public GenericRepository()
        {
             context=new AppDbContext();
        }
        public int Commit(T entity)
        {
            AppDbContext _context=new AppDbContext();
            _context.Set<T>().Update(entity);
            return _context.SaveChanges();
        }
        

        public void Create(T entity)
        => context.Set<T>().Add(entity);

        public void Delete(T entity)
        {
           var del= context.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            del.IsDeleted = true;
            context.Update(del);
            context.SaveChanges();
        }

        public List<T> GetAll()
        => context.Set<T>().ToList();

        public T GetById(int id)
        => context.Set<T>().FirstOrDefault(x => x.Id == id);

        public int SaveChanges()
        => context.SaveChanges();
    }
}
