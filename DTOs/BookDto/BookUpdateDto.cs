using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.DTOs.BookDto
{
    public class BookUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishYear { get; set; }
        public List<Author> Authors { get; set; }

        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
