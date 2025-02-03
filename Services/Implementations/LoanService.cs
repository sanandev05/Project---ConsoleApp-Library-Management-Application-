using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BorrowerDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.LoanDto;
using Project___ConsoleApp__Library_Management_Application_.Exceptions.GeneralExceptions;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Implementations;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces;
using Project___ConsoleApp__Library_Management_Application_.Services.Interfaces;

namespace Project___ConsoleApp__Library_Management_Application_.Services.Implementations
{
    public class LoanService : ILoanService
    {
        ILoanRepository loanRepository =new LoanRepository();
        public void Create(LoanCreateDto dto)
        {
            if (dto.BorrowerId < 1) throw new IdNotTrueException(" Id cant be zero and less than 0");

            Loan loan = new Loan()
            {
                BorrowerId = dto.BorrowerId,
                Borrower = dto.Borrower,
                LoanItems = dto.LoanItems,
                LoanDate = dto.LoanDate,
                IsDeleted = dto.IsDeleted,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                MustReturnDate = dto.MustReturnDate,
                ReturnDate = dto.ReturnDate,
            };
            loanRepository.Create(loan);
            loanRepository.Commit();
        }

        public void Delete(int id)
        {
            if (id < 1) throw new IdNotTrueException(" Id cant be zero and less than 0");
            var dto=loanRepository.GetByIdWithInclude(id);

            var loan = new Loan()
            {
                BorrowerId = dto.BorrowerId,
                Borrower = dto.Borrower,
                LoanItems = dto.LoanItems,
                LoanDate = dto.LoanDate,
                IsDeleted = dto.IsDeleted,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                MustReturnDate = dto.MustReturnDate,
                ReturnDate = dto.ReturnDate,
            };

            loanRepository.Delete(loan);
            loanRepository.Commit();
        }

        public List<LoanGetDto> GetAll()
        {
            return loanRepository.GetAllWithInclude().Where(x=>!x.IsDeleted).Select(x => new LoanGetDto()
            {
                BorrowerId = x.BorrowerId,
                Borrower = x.Borrower,
                LoanItems = x.LoanItems,
                LoanDate = x.LoanDate,
                IsDeleted = x.IsDeleted,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                MustReturnDate = x.MustReturnDate,
                ReturnDate = x.ReturnDate,
            }).ToList();
        }

        public LoanGetDto GetById(int id)
        {
            var get = loanRepository.GetByIdWithInclude(id);
            if (!get.IsDeleted)
            {
                LoanGetDto dto = new LoanGetDto()
                {
                    BorrowerId = get.BorrowerId,
                    Borrower = get.Borrower,
                    LoanItems = get.LoanItems,
                    LoanDate = get.LoanDate,
                    IsDeleted = get.IsDeleted,
                    CreatedAt = get.CreatedAt,
                    UpdatedAt = get.UpdatedAt,
                    MustReturnDate = get.MustReturnDate,
                    ReturnDate = get.ReturnDate,
                };
                return dto;
            }
            return null;
        }
    }
}
