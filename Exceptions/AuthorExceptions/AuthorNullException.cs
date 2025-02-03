using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Exceptions.AuthorExceptions
{
    public class AuthorNullException : Exception
    {
        public AuthorNullException()
        {
        }
        public AuthorNullException(string message) : base(message)
        {
        }
    }
}
