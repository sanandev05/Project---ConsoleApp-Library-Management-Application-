using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Exceptions.BorrowerExceptions
{
    public class BorrowerNameOrEmailNullOrWhiteSpaceException : Exception
    {
        public BorrowerNameOrEmailNullOrWhiteSpaceException()
        {
        }
        public BorrowerNameOrEmailNullOrWhiteSpaceException(string message) : base(message) 
        {
        }
    }
}
