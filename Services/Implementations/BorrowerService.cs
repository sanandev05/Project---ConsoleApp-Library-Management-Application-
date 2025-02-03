using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BookDto;
using Project___ConsoleApp__Library_Management_Application_.DTOs.BorrowerDto;
using Project___ConsoleApp__Library_Management_Application_.Exceptions.BorrowerExceptions;
using Project___ConsoleApp__Library_Management_Application_.Exceptions.GeneralExceptions;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Implementations;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces;
using Project___ConsoleApp__Library_Management_Application_.Services.Interfaces;

namespace Project___ConsoleApp__Library_Management_Application_.Services.Implementations
{
    public class BorrowerService : IBorrowerService
    {
        IBorrowerRepository borrowerRepository = new BorrowerRepository(); 
        public void Create(BorrowerCreateDto entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name) || string.IsNullOrWhiteSpace(entity.Email))
            throw new BorrowerNameOrEmailNullOrWhiteSpaceException("Borrower Name Or Email is Null Or White Space");

            Borrower borrower = new Borrower()
            {
                Name = entity.Name,
                Email = entity.Email,
                IsDeleted = entity.IsDeleted,
                Loans = entity.Loans,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
            };

            borrowerRepository.Create(borrower);
        }

        public void Delete(int id)
        {
            if (id < 1) throw new IdNotTrueException("Id cant be zero or below it !"); 

            Borrower borrower =borrowerRepository.GetByIdWithInclude(id);
            borrowerRepository.Delete(borrower);
            
        }

        public List<BorrowerGetDto> GetAll()
        {
            var get = borrowerRepository.GetAllWithInclude();
            var data = new List<BorrowerGetDto>();
            return data = get.Select(x => new BorrowerGetDto()
            {
               Id = x.Id, 
               Name = x.Name,
               Email = x.Email,
               IsDeleted = x.IsDeleted,
               CreatedAt= x.CreatedAt,
               UpdatedAt= x.UpdatedAt,
            }).ToList();
        }

        public BorrowerGetDto GetById(int id)
        {
            var get = borrowerRepository.GetByIdWithInclude(id);
            BorrowerGetDto dto = new BorrowerGetDto()
            {
                Id = get.Id,
                Name = get.Name,
                Email = get.Email,
                IsDeleted = get.IsDeleted,
                CreatedAt = get.CreatedAt,
                UpdatedAt = get.UpdatedAt,
            };
            return dto;
        }
    }
}
