using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___ConsoleApp__Library_Management_Application_.Exceptions.BorrowerExceptions
{
    public class BorrowerNotFound : Exception
    {
        public BorrowerNotFound()
        {
        }
        public BorrowerNotFound(string message) : base(message) 
        {
        }
    }
}
