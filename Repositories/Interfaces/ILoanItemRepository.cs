using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces
{
    public interface ILoanItemRepository
    {
        public void Create(LoanItem entity);
        public void Delete(LoanItem entity);
        LoanItem GetById(int id);
        List<LoanItem> GetAll();
        int Commit();
    }
}
