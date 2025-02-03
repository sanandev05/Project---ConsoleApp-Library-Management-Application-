using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.DTOs.AuthorDto;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.DTOs
{
    public interface IAuthorService
    {
        public void Create(AuthorCreateDto dto);
        public void Delete(int id);
        public void Update(int id,AuthorUpdateDto dto);
        AuthorGetDto GetById(int id);
        List<AuthorGetDto> GetAll();
    }
}
