using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _loanItemRepository.Commit();
        }

        public void Delete(int id)
        {
            if (id < 1) throw new IdNotTrueException(" Id cant be zero and less than 0");
            var dto = _loanItemRepository.GetByIdWithInclude(id);

            var loan = new LoanItem()
            {
                BookId = dto.BookId,
                LoanId = dto.LoanId,
                Book = dto.Book,
                Loan = dto.Loan,
                IsDeleted = dto.IsDeleted,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
            };

            _loanItemRepository.Delete(loan);
            _loanItemRepository.Commit();
        }

        public List<LoanItemGetDto> GetAll()
        {
            return _loanItemRepository.GetAllWithInclude().Where(x => !x.IsDeleted).Select(x => new LoanItemGetDto()
            {
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
    }
}
