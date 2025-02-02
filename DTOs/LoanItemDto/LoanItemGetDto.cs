using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.DTOs.LoanItemDto
{
    public class LoanItemGetDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int LoanId { get; set; }
        public Loan Loan { get; set; } // Navigation Property
        public Book Book { get; set; } // Navigation Property
    }
}
