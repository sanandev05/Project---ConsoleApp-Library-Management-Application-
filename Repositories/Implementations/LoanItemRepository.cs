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
    public class LoanItemRepository : GenericRepository<LoanItem>,ILoanItemRepository
    {
        AppDbContext _dbContext = new AppDbContext();
        public LoanItem GetByIdWithInclude(int id)
        {
            
            LoanItem loanItem = _dbContext.LoanItems.Include(x => x.Loan).Include(x => x.Book).FirstOrDefault(n => n.Id == id);
            return loanItem;
        }
        public List<LoanItem> GetAllWithInclude()
        {
            return _dbContext.LoanItems.Include(x => x.Loan).Include(x => x.Book).ToList();
        }
       
    }
}
