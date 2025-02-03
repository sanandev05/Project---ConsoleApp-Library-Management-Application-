using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.DTOs.AuthorDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.LoanItemDto;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.Services.Interfaces
{
    public interface ILoanItemService
    {
        public void Create(LoanItemCreateDto entity);
        public void Delete(int id);
        public void Update(LoanItemUpdateDto dto);
        LoanItemGetDto GetById(int id);
        List<LoanItemGetDto> GetAll();
    }
}
