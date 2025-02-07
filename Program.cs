using Microsoft.IdentityModel.Tokens;
using Project___ConsoleApp__Library_Management_Application_.DTOs;
using Project___ConsoleApp__Library_Management_Application_.DTOs.AuthorDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BookDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BorrowerDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.LoanDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.LoanItemDto;
using Project___ConsoleApp__Library_Management_Application_.Exceptions.BookExceptions;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Implementations;
using Project___ConsoleApp__Library_Management_Application_.Services.Implementations;
using Project___ConsoleApp__Library_Management_Application_.Services.Interfaces;

namespace Project___ConsoleApp__Library_Management_Application_
{
    internal class Program
    {

        static void Main(string[] args)
        {
            StartProgram();
        }



        static void AuthorActions(int cmd)
        {
            IAuthorService authorService = new AuthorService();
            switch (cmd)
            {
                case 1:
                    Console.WriteLine("List of Authors:\n");
                    var datas = authorService.GetAll();
                    if (!datas.IsNullOrEmpty())
                        foreach (var item in datas)
                        {
                            Console.WriteLine($"{item.Id} {item.Name} {item.CreatedAt} {item.UpdatedAt} {item.IsDeleted}");
                        }
                    else Console.WriteLine("There is nothing in the Authors List");
                    break;
                case 2:
                    try
                    {
                        Console.WriteLine("Creating Author:\n");
                        Console.Write("Name of Author :");
                        string name = Console.ReadLine();
                        AuthorCreateDto authorCreateDto = new AuthorCreateDto()
                        {
                            Name = name,
                            IsDeleted = false,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                        };
                        authorService.Create(authorCreateDto);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again");
                    }
                    break;
                case 3:

                wrongFormat:
                    int id;
                    try
                    {
                        Console.Write("Enter the ID to Modify Author:");
                        id = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Write in valid format");
                        goto wrongFormat;
                    }
                    try
                    {
                        Console.Write("Enter the new Name:");
                        string updateName = Console.ReadLine();
                        AuthorUpdateDto authorUpdateDto = new AuthorUpdateDto()
                        {
                            Name = updateName,
                            IsDeleted = false,
                            UpdatedAt = DateTime.Now,

                        };

                        authorService.Update(id, authorUpdateDto);

                    }
                    catch (BookPublishedYearNotTrueException e)
                    {
                        goto wrongFormat;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again");
                        goto wrongFormat;
                    }

                    break;
                case 4:
                    Console.WriteLine("Deleting an Author:\n");

                wrongFormat2:
                    Console.Write("Enter the ID Correctly:");
                    try
                    {
                        int Id = int.Parse(Console.ReadLine());                   
                        authorService.SoftDeleteAuthor(Id);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again");
                        goto wrongFormat2;
                    }
                    break;
                case 0:
                    StartProgram();
                    break;
                default:
                    StartProgram();
                    break;
            }
        }
        static void BookActions(int cmd)
        {
            BookService bookService = new BookService();
            IAuthorService authorService = new AuthorService();
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

                    Console.WriteLine("Creating Book :\n");
                    string title;
                    do
                    {
                        Console.Write("Title of the Book :");
                        title = Console.ReadLine();

                    } while (string.IsNullOrWhiteSpace(title));
                    string description;
                    do
                    {
                        Console.Write("Description of the Book :");
                        description = Console.ReadLine();

                    } while (string.IsNullOrWhiteSpace(description));

                wrongFormat:
                    int publishYear;
                    try
                    {
                        do
                        {
                            Console.Write("Publish Year of the Book :");
                            publishYear = int.Parse(Console.ReadLine());
                        } while (publishYear < 1000 || publishYear > DateTime.Now.Year);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Write in valid format");
                        goto wrongFormat;
                    }



                wrongFormat5:

                    int authorId;
                    try
                    {
                        do
                        {
                            Console.Write("Author Id of the Book:");
                            authorId = int.Parse(Console.ReadLine());

                        } while (authorId < 1 && authorService.GetById(authorId) is null);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Write in valid format");
                        goto wrongFormat5;
                    }

                    while (authorService.GetById(authorId) is null)
                    {
                        goto wrongFormat5;

                    }
                    var author = authorService.GetById(authorId);
                    Author author1 = new Author()
                    {
                        Id = authorId,
                        Name = author.Name,
                        Books = author.Books,
                        CreatedAt = author.CreatedAt,
                        UpdatedAt = author.UpdatedAt,
                        IsDeleted = author.IsDeleted,
                    };
                    BookCreateDto bookCreateDto = new BookCreateDto()
                    {
                        Title = title,
                        IsDeleted = false,
                        Description = description,
                        PublishYear = publishYear,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Authors = new List<Author>() { author1 }

                    };
                    bookService.Create(authorId, bookCreateDto);

                    break;
                case 3:
                wrongFormat2:
                    int ID;
                    try
                    {
                        Console.Write("Enter ID of Book to Modify:");
                        do
                        {
                            ID = int.Parse(Console.ReadLine());

                        } while (ID < 1 || bookService.GetById(ID) is null);


                        string updateTitle;
                        do
                        {
                            Console.Write("New Title of Book :");
                            updateTitle = Console.ReadLine();

                        } while (string.IsNullOrEmpty(updateTitle));

                        string updatedDesc;
                        do
                        {
                            Console.Write("New Description of Book :");
                            updatedDesc = Console.ReadLine();

                        } while (string.IsNullOrEmpty(updatedDesc));

                        int updatedPublishYear;
                        do
                        {

                            Console.Write("New Publish Year of Book :");

                            updatedPublishYear = int.Parse(Console.ReadLine());

                        } while (updatedPublishYear < 1000 || updatedPublishYear > DateTime.Now.Year);




                        BookUpdateDto updateBookDto = new BookUpdateDto()
                        {
                            Title = updateTitle,
                            IsDeleted = false,
                            Description = updatedDesc,
                            PublishYear = updatedPublishYear,
                            UpdatedAt = DateTime.Now,

                        };
                        bookService.Update(ID, updateBookDto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Try agian. Error message:{ex.Message}");
                        goto wrongFormat2;
                    }
                    break;
                case 4:
                    Console.WriteLine("Deleting a Book:\n");
                wrongFormat4:
                    int Id = 0;
                    try
                    {
                        do
                        {
                            Console.Write("Enter the ID Correctly:");
                            Id = int.Parse(Console.ReadLine());
                        } while (Id < 1 || bookService.GetById(Id) is null);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Write in valid format");
                        goto wrongFormat4;
                    }

                    try
                    {
                        bookService.SoftDeleteBook(Id);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again");
                        goto wrongFormat4;
                    }

                    break;
                case 0:
                    StartProgram();
                    break;
                default:
                    StartProgram();
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
                    else Console.WriteLine("There is nothing in the Borrowers List");
                    break;

                case 2:
                    Console.WriteLine("Creating Borrower:\n");
                    string name;
                    do
                    {
                        Console.Write("Name of the Borrower :");
                        name = Console.ReadLine();

                    } while (string.IsNullOrEmpty(name));
                    string email;
                    do
                    {
                        Console.Write("Email of Borrower :");
                        email = Console.ReadLine();

                    } while (string.IsNullOrEmpty(email));

                    BorrowerCreateDto borrowerCreateDto = new BorrowerCreateDto()
                    {
                        Name = name,
                        IsDeleted = false,
                        Email = email,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                    borrowerService.Create(borrowerCreateDto);
                    break;
                case 3:
                wrongFormat:
                    int ID;
                    try
                    {
                        do
                        {
                            Console.Write("Enter ID of Borrower to Modify:");
                            ID = int.Parse(Console.ReadLine());

                        } while (ID < 1 || borrowerService.GetById(ID) is null);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Write in valid format");
                        goto wrongFormat;
                    }
                    try
                    {
                        string updatedName;
                        do
                        {
                            Console.Write("New Name of the Borrower :");
                            updatedName = Console.ReadLine();

                        } while (string.IsNullOrWhiteSpace(updatedName));

                        string updatedEmail;
                        do
                        {
                            Console.Write("New Email of the Borrower :");
                            updatedEmail = Console.ReadLine();

                        } while (string.IsNullOrWhiteSpace(updatedEmail));

                        BorrowerUpdateDto borrowerUpdateDto = new BorrowerUpdateDto()
                        {
                            Name = updatedName,
                            IsDeleted = false,
                            Email = updatedEmail,
                            UpdatedAt = DateTime.Now,
                        };
                        borrowerService.Update(ID, borrowerUpdateDto);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again");
                        goto wrongFormat;
                    }
                    break;
                case 4:
                    Console.WriteLine("Deleting a Borrower:\n");
                    ILoanService loanService = new LoanService(); 
                    ILoanItemService loanItemService = new LoanItemService();   
                wrongFormat2:
                    int Id = 0;
                    try
                    {
                        do
                        {
                            Console.Write("Enter the Borrower ID Correctly:");
                            Id = int.Parse(Console.ReadLine());

                        } while (Id < 1 || borrowerService.GetById(Id) is null);
                        borrowerService.Delete(Id);
                        var loans=loanService.GetAll().Where(x => x.BorrowerId == Id);
                        foreach (var item in loans)
                        {
                            loanService.Delete(item.Id);
                            foreach (var loanItem in loanItemService.GetAll().Where(x=>x.LoanId==item.Id))
                            {
                                loanItemService.Delete(loanItem.Id);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again");
                        goto wrongFormat2;
                    }

                    break;
                case 0:
                    StartProgram();
                    break;
                default:
                    StartProgram();
                    break;
            }
        }
        static void BorrowBook()
        {
            IBookService bookService = new BookService();
            ILoanItemService loanItemService = new LoanItemService();

            int selectedBookId = 0;

            Console.WriteLine("All list of Books. Borrow book with ID:\n");
            List<LoanItemGetDto> loanItemGetDtos = new List<LoanItemGetDto>();
            List<int>? bookLoanIds = new List<int>();
            List<int>? availableBookIDs = new List<int>();
            foreach (var item in bookService.GetAll())
            {
                loanItemGetDtos = loanItemService.GetAll();
                var loanItemGet = loanItemGetDtos.FirstOrDefault(x => x.BookId == item.Id);

                // Console.WriteLine(loanItemGetDtos.FirstOrDefault(x => x.BookId == item.Id).BookId);
                if (loanItemGet is null)
                {
                    Console.WriteLine($"{item.Id} {item.Title} {item.Description} {item.PublishYear} {item.CreatedAt} {item.UpdatedAt} {item.IsDeleted}");
                    availableBookIDs.Add((int)item.Id);
                }
                else
                {
                    if (item.Id == loanItemGetDtos.FirstOrDefault(x => x.BookId == item.Id).BookId)
                    {
                        bookLoanIds.Add(loanItemGetDtos.FirstOrDefault(x => x.BookId == item.Id).BookId);
                        Console.WriteLine($"Not Availabe - {item.Id} {item.Title} {item.Description} {item.PublishYear} {item.CreatedAt} {item.UpdatedAt} {item.IsDeleted}");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Id} {item.Title} {item.Description} {item.PublishYear} {item.CreatedAt} {item.UpdatedAt} {item.IsDeleted}");
                        int? nullAbleId = item.Id;
                        availableBookIDs.Add((int)nullAbleId);
                    }
                }
            }
        wrongFormat:
            try
            {
                int ID = 0;
                int get = 0;
                do
                {
                    Console.WriteLine("\nID to borrow:");
                    ID = int.Parse(Console.ReadLine());

                } while (availableBookIDs.FirstOrDefault(x => x == ID) != ID);

                selectedBookId = ID;
                do
                {
                    Console.WriteLine("1- Add other book \n2-Add Borrower");
                    get = int.Parse(Console.ReadLine());

                } while (get != 1 && get != 2);


                int getBorrowerWithId = 0;


                switch (get)
                {
                    case 1:
                        BorrowBook();
                        return;
                        break;
                    case 2:
                        IBorrowerService borrowerService = new BorrowerService();
                        Console.WriteLine("List of Borrowers:\n");
                        var datas = borrowerService.GetAll();
                        if (!datas.IsNullOrEmpty())
                            foreach (var item in datas)
                            {
                                Console.WriteLine($"{item.Id} {item.Name} {item.Email} {item.CreatedAt} {item.UpdatedAt} {item.IsDeleted}");
                            }
                        else { Console.WriteLine("There is nothing in the Borrowers List"); }

                        BorrowerGetDto getBorrower;
                        do
                        {
                            Console.WriteLine("Select Borrower Correctly:");
                            getBorrowerWithId = int.Parse(Console.ReadLine());
                            getBorrower = borrowerService.GetById(getBorrowerWithId);

                        } while (getBorrower is null);



                        break;
                    default:
                        break;
                }
                Console.WriteLine("Enter 1 Confirm");
                int? getConfirmCmd = int.Parse(Console.ReadLine());

                ILoanService loanService = new LoanService();

                LoanCreateDto loanCreateDto = new LoanCreateDto()
                {
                    BorrowerId = getBorrowerWithId,
                    MustReturnDate = DateTime.Now.AddDays(15),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false,
                    LoanDate = DateTime.Now,

                };
                loanService.Create(loanCreateDto);

                var ar = loanService.GetAll().FindAll(x => x.BorrowerId == getBorrowerWithId).OrderByDescending(x => x.Id).ToArray();
                LoanItemCreateDto loanItem = new LoanItemCreateDto()
                {
                    BookId = selectedBookId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false,
                    LoanId = ar[0].Id,
                };
                loanItemService.Create(loanItem);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again");
                goto wrongFormat;
            }
        }
        static void ReturnBook()
        {
            int getBorrowerWithId = 0;
            IBorrowerService borrowerService = new BorrowerService();
            ILoanService loanService = new LoanService();
            ILoanItemService loanItemService = new LoanItemService();
            Console.WriteLine("List of Borrowers:\n");
            var datas = borrowerService.GetAll();
            if (!datas.IsNullOrEmpty())
                foreach (var item in datas)
                {
                    Console.WriteLine($"{item.Id} {item.Name} {item.Email} {item.CreatedAt} {item.UpdatedAt} {item.IsDeleted}");
                }
            else { Console.WriteLine("There is nothing in the Borrowers List"); }

            LoanGetDto getUpdatedForm;
            BorrowerGetDto getBorrower;
        wrongFormat:
            try
            {
                do
                {
                    Console.WriteLine("Select Borrower to Return Book :");
                    getBorrowerWithId = int.Parse(Console.ReadLine());
                    getBorrower = borrowerService.GetById(getBorrowerWithId);

                } while (getBorrower is null);
                getUpdatedForm = loanService.GetAll().FirstOrDefault(x => x.BorrowerId == getBorrowerWithId);

                //Check  borrower loaned a book 
                if (getUpdatedForm is not null)
                {
                    LoanUpdateDto updateLoan = new LoanUpdateDto()
                    {
                        ReturnDate = DateTime.Now,
                        BorrowerId = getUpdatedForm.BorrowerId,
                        IsDeleted = false,
                        LoanDate = getUpdatedForm.LoanDate,
                        UpdatedAt = DateTime.Now,
                        MustReturnDate = getUpdatedForm.MustReturnDate,
                    };
                    loanService.Update(getUpdatedForm.Id, updateLoan);
                    var loanItemIdToDelete = loanItemService.GetAll().FirstOrDefault(x => x.LoanId == getUpdatedForm.Id).Id;
                    if (loanItemIdToDelete is 0) { Console.WriteLine("LoanItem didnot found"); }
                    int returningBookID = loanItemService.GetAll().FirstOrDefault(x => x.LoanId == getUpdatedForm.Id).BookId;

                    if (loanItemIdToDelete is 0) { Console.WriteLine(""); }
                    loanItemService.Delete(loanItemIdToDelete);
                    loanService.Delete(getUpdatedForm.Id);
                    Console.WriteLine($"You returned book ID: {returningBookID}");
                }
                else
                {
                    Console.WriteLine("You may be didnot borrow a book");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again");
                goto wrongFormat;
            }

        }
        static void PrintMostBorrowedBook()
        {
            BookService bookService = new BookService();
            try
            {
                var book = bookService.GetById(bookService.MostLoanedBookID());
                Console.WriteLine($"ID:{book.Id} - Book title:{book.Title} - Book description: {book.Description} - Publish year: {book.PublishYear}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong. Error message:{e.Message}");
            }
        }
        static void PrintOverDueBorrowers()
        {
            ILoanService loanService = new LoanService();
            var loaners = loanService.GetAll().FindAll(x => x.ReturnDate is null);
            if (loaners.Count > 0)
            {
                foreach (var item in loaners)
                {
                    Console.WriteLine($"ID:{item.Id} BorrowerID:{item.BorrowerId} Borrower Name:{item.Borrower.Name} Must Return:{item.MustReturnDate} ");
                }
            }
            else
            {
                Console.WriteLine("Every one returned their books :)");
            }
        }
        static void PrintBorrowersLoanInfo()
        {
            LoanItemService loanItemService = new LoanItemService();
            loanItemService.PrintBorrowersLoansInfo();
        }
        static void FilterBooksByTitle()
        {
            IBookService bookService = new BookService();
            List<string> bookTitles = bookService.GetAll().Select(x => x.Title).ToList();
            string input;
            Console.WriteLine("If you wanna exit , enter 0\n");
            do
            {
                Console.Write("Serach:");
                input = Console.ReadLine().Trim();

                string search = bookTitles.FirstOrDefault(x => x.Contains(input));
                if (string.IsNullOrWhiteSpace(search) == false)
                {
                    Console.WriteLine("Result:" + search + "\n");
                }
                else if (string.IsNullOrWhiteSpace(search) && input != "0")
                {
                    Console.WriteLine("Book Not Found\n");
                }

            } while (input.Trim() != "0");
        }
        static void FilterBooksByAuthor()
        {
            IBookService bookService = new BookService();
            var books = bookService.GetAll();
            string input;

            Console.WriteLine("Search a book with Author Name . To get all books with authors just press enter.");
            Console.WriteLine("If you wanna exit , enter 0\n");
            do
            {
                Console.Write("Serach:");
                input = Console.ReadLine().Trim();

                foreach (var book in books)
                {
                    foreach (var author in book.Authors)
                    {
                        if (author.Name.ToLower().Contains(input.ToLower()))
                        {
                            if (!string.IsNullOrEmpty(book.Title))
                            {
                                Console.WriteLine($"{author.Name} of Book(s):");
                                Console.WriteLine($"{book.Title}\n");
                            }
                            else
                            {
                                Console.WriteLine($"Not Found {author.Name}'s Book(s)");
                            }
                        }
                    }
                }

            } while (input.Trim() != "0");
        }
        private static void StartProgram()
        {
            Console.Clear();
        wrong:
            int input;
            try
            {
                Console.WriteLine(InfoStrings.ActionsInfo);


                Console.Write("Select one action with its number:");
                input = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again\n");
                goto wrong;
            }

            switch (input)
            {
                case 1:
                gocase1:
                    int inputCase1;
                    try
                    {
                        Console.Clear();
                        Console.WriteLine(InfoStrings.AuthorActionsInfo + "\n");
                        Console.Write("Select:");
                        inputCase1 = int.Parse(Console.ReadLine());

                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again\n");
                        goto gocase1;
                    }
                    AuthorActions(inputCase1);
                    break;
                case 2:
                gocase2:
                    int inputCase2;
                    try
                    {
                        Console.Clear();
                        Console.WriteLine(InfoStrings.BookActionsInfo + "\n");
                        inputCase2 = int.Parse(Console.ReadLine());

                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again\n");
                        goto gocase2;
                    }
                    BookActions(inputCase2);
                    break;
                case 3:
                    try
                    {
                        Console.Clear();
                        Console.WriteLine(InfoStrings.BorrowerActionsInfo + "\n");
                        BorrowerActions(int.Parse(Console.ReadLine()));
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine($"Something went wrong .Error message:{e.Message}. Try again\n");
                        goto wrong;
                    }

                    break;
                case 4:
                    Console.Clear();
                    BorrowBook();
                    break;
                case 5:
                    Console.Clear();
                    ReturnBook();
                    break;
                case 6:
                    Console.Clear();
                    PrintMostBorrowedBook();
                    break;
                case 7:
                    Console.Clear();
                    PrintOverDueBorrowers();
                    break;
                case 8:
                    Console.Clear();
                    PrintBorrowersLoanInfo();
                    break;
                case 9:
                    Console.Clear();
                    FilterBooksByTitle();
                    break;
                case 10:
                    Console.Clear();
                    FilterBooksByAuthor();
                    break;
                case 0:
                    break;
                default:
                    Console.Clear();
                    goto wrong;
                    break;

            }
        }

    }
}
