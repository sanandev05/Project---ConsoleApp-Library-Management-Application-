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
    public class LoanRepository : GenericRepository<Loan>,ILoanRepository
    {
        AppDbContext _dbContext = new AppDbContext();
        public Loan GetByIdWithInclude(int id)
        {
            Loan loan = _dbContext.Loans.Include(x=>x.Borrower).Include(x=>x.LoanItems).ThenInclude(x=>x.Book).FirstOrDefault(x=>x.Id==id);
            return loan;
        }
        public List<Loan> GetAllWithInclude()
        {
            return _dbContext.Loans.Include(x => x.Borrower).Include(x => x.LoanItems).ThenInclude(x => x.Book).ToList();
        }
      
    }
}
