using Project___ConsoleApp__Library_Management_Application_.DTOs;
using Project___ConsoleApp__Library_Management_Application_.Services.Implementations;

namespace Project___ConsoleApp__Library_Management_Application_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        static void AuthorActions(int cmd)
        {
            IAuthorService authorService = new AuthorService();
            switch (cmd)
            {
                case 1:
                    foreach (var item in authorService.GetAll())
                    {
                      
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
