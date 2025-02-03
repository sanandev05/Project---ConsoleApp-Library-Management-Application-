using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.DTOs.AuthorDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BorrowerDto;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.Services.Interfaces
{
    public  interface IBorrowerService
    {
        public void Create(BorrowerCreateDto entity);
        public void Delete(int id);
        public void Update(BorrowerUpdateDto dto);
        BorrowerGetDto GetById(int id);
        List<BorrowerGetDto> GetAll();
    }
}
