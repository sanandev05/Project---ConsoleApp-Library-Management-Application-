using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.DTOs.BorrowerDto
{
    public class BorrowerCreateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
