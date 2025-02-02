using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces
{
    public interface ILoanRepository
    {
        public void Create(Loan entity);
        public void Delete(Loan entity);
        Loan GetById(int id);
        List<Loan> GetAll();
        int Commit();
    }
}
