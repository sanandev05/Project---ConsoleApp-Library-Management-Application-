using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.DTOs.LoanDto;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.Services.Interfaces
{
    public interface ILoanService
    {
        public void Create(LoanCreateDto dto);
        public void Delete(int id);
        LoanGetDto GetById(int id);
        List<LoanGetDto> GetAll();
    }
}
