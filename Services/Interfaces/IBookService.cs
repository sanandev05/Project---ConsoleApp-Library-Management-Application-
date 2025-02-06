using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.DTOs.AuthorDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BookDto;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.Services.Interfaces
{
    public interface IBookService
    {
        public void Create(int authorID,BookCreateDto entity);
        public void Delete(int id);
        public void Update(int id,BookUpdateDto dto);

        BookGetDto GetById(int id);
        List<BookGetDto> GetAll();
    }
}
