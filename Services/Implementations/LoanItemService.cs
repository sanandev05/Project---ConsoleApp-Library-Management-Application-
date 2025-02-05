using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BorrowerDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.LoanDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.LoanItemDto;
using Project___ConsoleApp__Library_Management_Application_.Exceptions.BorrowerExceptions;
using Project___ConsoleApp__Library_Management_Application_.Exceptions.GeneralExceptions;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Implementations;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces;
using Project___ConsoleApp__Library_Management_Application_.Services.Interfaces;

namespace Project___ConsoleApp__Library_Management_Application_.Services.Implementations
{
    public class LoanItemService : ILoanItemService
    {
        ILoanItemRepository _loanItemRepository = new LoanItemRepository();
        public void Create(LoanItemCreateDto entity)
        {
            if (entity == null) throw new ArgumentNullException("LoanItem is null");
            LoanItem loanItem = new LoanItem()
            {
                BookId = entity.BookId,
                LoanId = entity.LoanId,
                Book = entity.Book,
                Loan = entity.Loan,
                IsDeleted = entity.IsDeleted,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
            };

            _loanItemRepository.Create(loanItem);
            _loanItemRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id < 1) { throw new IdNotTrueException(" Id cant be zero and less than 0"); }

            var dto = _loanItemRepository.GetByIdWithInclude(id);

            var loan = new LoanItem()
            {
                Id = dto.Id,
                BookId = dto.BookId,
                LoanId = dto.LoanId,
                Book = dto.Book,
                Loan = dto.Loan,
                IsDeleted = dto.IsDeleted,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
            };

            _loanItemRepository.Delete(loan);
            _loanItemRepository.SaveChanges();
        }

        public List<LoanItemGetDto> GetAll()
        {
            return _loanItemRepository.GetAllWithInclude().Where(x => !x.IsDeleted).Select(x => new LoanItemGetDto()
            {
                Id = x.Id,
                BookId = x.BookId,
                LoanId = x.LoanId,
                Book = x.Book,               
                Loan = x.Loan,
                IsDeleted = x.IsDeleted,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
            }).ToList();
        }

        public LoanItemGetDto GetById(int id)
        {
            var get = _loanItemRepository.GetByIdWithInclude(id);
            if (!get.IsDeleted)
            {
                LoanItemGetDto dto = new LoanItemGetDto()
                {
                    Id = id,
                    BookId = get.BookId,
                    LoanId = get.LoanId,
                    Book = get.Book,
                    Loan = get.Loan,
                    IsDeleted = get.IsDeleted,
                    CreatedAt = get.CreatedAt,
                    UpdatedAt = get.UpdatedAt,
                };
                return dto;
            }
            else
            {
                return null;
            }
        }

        public void Update(int id, LoanItemUpdateDto dto)
        {
            LoanItemRepository loanItemRepo = new LoanItemRepository();
            if (dto == null) throw new ArgumentNullException("LoanItem is null");

            if (!dto.IsDeleted)
            {
                LoanItem loanItem = loanItemRepo.GetByIdWithInclude(id);
                loanItem.Id = id;
                loanItem.BookId = dto.BookId;
                loanItem.LoanId = dto.LoanId;
                loanItem.Book = dto.Book;
                loanItem.Loan = dto.Loan;
                loanItem.IsDeleted = dto.IsDeleted;

                loanItemRepo.Commit(loanItem);
                loanItemRepo.SaveChanges();
            }
            else throw new NullReferenceException("Not Found LoanItem");
        }

        public void PrintBorrowersLoansInfo()
        {
            IBorrowerRepository borrowerRepository = new BorrowerRepository();
            ILoanItemRepository loanItemRepository = new LoanItemRepository();
            IBookRepository bookRepository = new BookRepository();
            List<Borrower> borrowers = borrowerRepository.GetAllWithInclude();
            foreach (var item in borrowers)
            {
                Console.WriteLine($"\n{item.Id} {item.Name} Book Loans-> \n\n");
                
                foreach (var loans in loanItemRepository.GetAllWithInclude())
                {
                   
                    if (loans.Loan.BorrowerId == item.Id)
                    {
                        Console.WriteLine($"{loans.Book.Title} {loans.Book.Description}");
                
                     
                    }
                }
            }
        }
    }
}
