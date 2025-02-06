﻿using Microsoft.IdentityModel.Tokens;
using Project___ConsoleApp__Library_Management_Application_.DTOs;
using Project___ConsoleApp__Library_Management_Application_.DTOs.AuthorDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BookDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BorrowerDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.LoanDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.LoanItemDto;
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
            BookActions(2);
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
                    break;
                case 3:
                    Console.Write("Enter the ID:");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter the new Name:");
                    string updateName = Console.ReadLine();
                    AuthorUpdateDto authorUpdateDto = new AuthorUpdateDto()
                    {
                        Name = updateName,
                        IsDeleted = false,
                        UpdatedAt = DateTime.Now,
                    };
                    authorService.Update(id, authorUpdateDto);
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

                    AuthorRepository authorRepository = new AuthorRepository();
                    Console.WriteLine("Creating Book :\n");

                    Console.Write("Title of the Book :");
                    string title = Console.ReadLine();

                    Console.Write("Description of the Book :");
                    string description = Console.ReadLine();

                    Console.Write("Publish Year of the Book :");
                    int publishYear = int.Parse(Console.ReadLine());

                    Console.Write("Author Id of the Book:");
                    int authorId = int.Parse(Console.ReadLine());
                    var author= authorRepository.GetById(authorId);
                    BookCreateDto bookCreateDto = new BookCreateDto()
                    {
                        Title = title,
                        IsDeleted = false,
                        Description = description,
                        PublishYear = publishYear,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Authors= new List<Author>() { author }

                    };
                    bookService.Create(authorId, bookCreateDto);

                    break;
                case 3:
                    Console.Write("Enter ID of Book to Modify:");
                    int ID = int.Parse(Console.ReadLine());

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
                        UpdatedAt = DateTime.Now,
                    };
                    bookService.Update(ID, updateBookDto);
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
                    else Console.WriteLine("There is nothing in the Borrowers List");
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
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
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
                    borrowerService.Update(ID, borrowerUpdateDto);
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
            int ID;
            do
            {
                Console.WriteLine("\nID to borrow:");
                ID = int.Parse(Console.ReadLine());

            } while (availableBookIDs.FirstOrDefault(x => x == ID) != ID);

            selectedBookId = ID;
            int get;
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

            Console.WriteLine("GELE :" + loanService.GetAll().Find(x => x.BorrowerId == getBorrowerWithId).Id);
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

        /*  static void FilterBooksByAuthor()
          {
              IBookService bookService = new BookService();
              var bookAuthors = bookService.GetAll();

              string authorName;
              Console.WriteLine("If you wanna exit , enter 0\n");
              do
              {
                  Console.Write("Serach:");
                  authorName = Console.ReadLine().Trim();

                  string search;
                  if (string.IsNullOrWhiteSpace(search) == false)
                  {
                      Console.WriteLine("Result:" + search + "\n");
                  }
                  else if (string.IsNullOrWhiteSpace(search) && authorName != "0")
                  {
                      Console.WriteLine("Book Not Found\n");
                  }

              } while (input.Trim() != "0");
          }*/


    }
}
