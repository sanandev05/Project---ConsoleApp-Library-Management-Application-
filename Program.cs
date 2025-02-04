using Microsoft.IdentityModel.Tokens;
using Project___ConsoleApp__Library_Management_Application_.DTOs;
using Project___ConsoleApp__Library_Management_Application_.DTOs.AuthorDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BookDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BorrowerDto;
using Project___ConsoleApp__Library_Management_Application_.Services.Implementations;
using Project___ConsoleApp__Library_Management_Application_.Services.Interfaces;

namespace Project___ConsoleApp__Library_Management_Application_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookActions(4);
        }
        static void AuthorActions(int cmd)
        {
            IAuthorService authorService = new AuthorService();
            switch (cmd)
            {
                case 1:
                    Console.WriteLine("List of Authors:\n");
                    var datas = authorService.GetAll();
                    if(!datas.IsNullOrEmpty())
                    foreach (var item in datas)
                    {
                        Console.WriteLine($"{item.Id} {item.Name} {item.CreatedAt} {item.UpdatedAt} {item.IsDeleted}");
                    }
                    else Console.WriteLine("There is nothing in the Authors List");
                    break;
                case 2:
                    Console.WriteLine("Creating Author:\n");
                    Console.Write("Name of Author :");
                    string name = Console.ReadLine();
                    AuthorCreateDto authorCreateDto = new AuthorCreateDto()
                    {
                        Name = name,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now.AddHours(4),
                        UpdatedAt = DateTime.Now.AddHours(4),
                    };
                    authorService.Create(authorCreateDto);
                    break;
                case 3:
                    Console.Write("Enter the ID:");
                    int id=int.Parse(Console.ReadLine());
                    Console.Write("Enter the new Name:");
                    string updateName = Console.ReadLine();
                    AuthorUpdateDto authorUpdateDto = new AuthorUpdateDto()
                    {
                        Name = updateName,
                        IsDeleted = false,
                        UpdatedAt = DateTime.Now.AddHours(4),
                    };
                    authorService.Update(id,authorUpdateDto);
                    break;
                case 4:
                    Console.WriteLine("Deleting an Author:\n");
                    Console.Write("Enter the ID Correctly:");
                    int Id = int.Parse(Console.ReadLine());
                    authorService.Delete(Id);
                    break;
                case 0:
                    // WRITE 
                    break;
                default:
                    break;
            }
        }
        static void BookActions(int cmd)
        {
            IBookService bookService = new BookService();
            switch (cmd)
            {
                case 1:
                    Console.WriteLine("List of Book:\n");
                    var datas = bookService.GetAll();
                    if (!datas.IsNullOrEmpty())
                        foreach (var item in datas)
                        {
                            Console.WriteLine($"{item.Id} {item.Title} {item.Description} {item.PublishYear} {item.CreatedAt} {item.UpdatedAt} {item.IsDeleted}");
                        }
                    else Console.WriteLine("There is nothing in the Books List");
                    break;

                case 2:
                    Console.WriteLine("Creating Book:\n");

                    Console.Write("Title of Book :");
                    string title = Console.ReadLine();

                    Console.Write("Description of Book :");
                    string description = Console.ReadLine();

                    Console.Write("Publish Year of Book :");
                    int publishYear =int.Parse(Console.ReadLine());

                    BookCreateDto bookCreateDto = new BookCreateDto()
                    {
                        Title = title,
                        IsDeleted = false,
                        Description=description,
                        PublishYear=publishYear,
                        CreatedAt = DateTime.Now.AddHours(4),
                        UpdatedAt = DateTime.Now.AddHours(4),
                    };
                    bookService.Create(bookCreateDto);
                    break;
                case 3:
                    Console.Write("Enter ID of Book to Modify:");
                    int ID=int.Parse(Console.ReadLine());

                    Console.Write("New Title of Book :");
                    string updateTitle = Console.ReadLine();

                    Console.Write("New Description of Book :");
                    string updatedDesc = Console.ReadLine();

                    Console.Write("New Publish Year of Book :");
                    int updatedPublishYear = int.Parse(Console.ReadLine());

                    BookUpdateDto updateBookDto = new BookUpdateDto()
                    {
                        Title = updateTitle,
                        IsDeleted = false,
                        Description = updatedDesc,
                        PublishYear = updatedPublishYear,
                        UpdatedAt = DateTime.Now.AddHours(4),
                    };
                    bookService.Update(updateBookDto);
                    break;
                case 4:
                    Console.WriteLine("Deleting an Author:\n");
                    Console.Write("Enter the ID Correctly:");
                    int Id = int.Parse(Console.ReadLine());
                    bookService.Delete(Id);
                    break;
                case 0:
                    // WRITE 
                    break;
                default:
                    break;
            }
        }
        static void BorrowerActions(int cmd)
        {
            IBorrowerService borrowerService = new BorrowerService();
            switch (cmd)
            {
                case 1:
                    Console.WriteLine("List of Borrowers:\n");
                    var datas = borrowerService.GetAll();
                    if (!datas.IsNullOrEmpty())
                        foreach (var item in datas)
                        {
                            Console.WriteLine($"{item.Id} {item.Name} {item.Email} {item.CreatedAt} {item.UpdatedAt} {item.IsDeleted}");
                        }
                    else Console.WriteLine("There is nothing in the Books List");
                    break;

                case 2:
                    Console.WriteLine("Creating Borrower:\n");

                    Console.Write("Name of the Borrower :");
                    string name = Console.ReadLine();

                    Console.Write("Email of Borrower :");
                    string email = Console.ReadLine();

                    BorrowerCreateDto borrowerCreateDto = new BorrowerCreateDto()
                    {
                        Name = name,
                        IsDeleted = false,
                        Email = email,
                        CreatedAt = DateTime.Now.AddHours(4),
                        UpdatedAt = DateTime.Now.AddHours(4),
                    };
                    borrowerService.Create(borrowerCreateDto);
                    break;
                case 3:
                    Console.Write("Enter ID of Borrower to Modify:");
                    int ID = int.Parse(Console.ReadLine());

                    Console.Write("New Name of the Borrower :");
                    string updatedName = Console.ReadLine();

                    Console.Write("New Email of the Borrower :");
                    string updatedEmail = Console.ReadLine();

                    BorrowerUpdateDto borrowerUpdateDto = new BorrowerUpdateDto()
                    {
                        Name = updatedName,
                        IsDeleted = false,
                        Email = updatedEmail,
                        UpdatedAt = DateTime.Now.AddHours(4),
                    };
                    borrowerService.Update(borrowerUpdateDto);
                    break;
                case 4:
                    Console.WriteLine("Deleting an Borrower:\n");
                    Console.Write("Enter the Borrower ID Correctly:");
                    int Id = int.Parse(Console.ReadLine());
                    borrowerService.Delete(Id);
                    break;
                case 0:
                    // WRITE 
                    break;
                default:
                    break;
            }
        }
    }
}
