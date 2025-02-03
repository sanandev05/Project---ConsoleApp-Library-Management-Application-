using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Exceptions.BookExceptions
{
    public class BookPublishedYearNotTrueException : Exception
    {
        public BookPublishedYearNotTrueException()
        {
        }
        public BookPublishedYearNotTrueException(string message) : base(message) 
        {
        }
    }
}
