using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces
{
    public interface IBorrowerRepository
    {
        public void Create(Borrower entity);
        public void Delete(Borrower entity);
        public List<Borrower> GetAllWithInclude();
        public Borrower GetByIdWithInclude(int id);
        int Commit(Borrower borrower);
        int SaveChanges();

    }
}
