using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Exceptions.BookExceptions
{
    public class BookTitleOrDescriptionIsNullOrWhiteSpaceException : Exception
    {
        public BookTitleOrDescriptionIsNullOrWhiteSpaceException()
        {
        }
        public BookTitleOrDescriptionIsNullOrWhiteSpaceException(string message) : base(message) 
        {
        }
    }
}
