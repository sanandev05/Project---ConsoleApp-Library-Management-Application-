using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Exceptions.BookExceptions
{
    public class BookNullException : Exception
    {
        public BookNullException()
        {
        }
        public BookNullException(string message) : base(message) 
        {
        }
    }
}
