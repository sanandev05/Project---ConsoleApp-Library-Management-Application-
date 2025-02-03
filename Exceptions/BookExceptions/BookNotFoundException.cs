using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Exceptions.BookExceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException()
        {
        }
        public BookNotFoundException(string message) : base(message) 
        {
        }
    }
}
