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
    public class BorrowerRepository : GenericRepository<Borrower>,IBorrowerRepository
    {
        AppDbContext _dbContext = new AppDbContext();
        public Borrower GetByIdWithInclude(int id)
        {
            Borrower borrower = _dbContext.Borrowers.Include(x => x.Loans).FirstOrDefault(x=>x.Id==id);
            return borrower;
        }
        public List<Borrower> GetAllWithInclude()
        {
            return _dbContext.Borrowers.Include(x => x.Loans).ToList();
        }
    }
}
