﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project___ConsoleApp__Library_Management_Application_.Data;
using Project___ConsoleApp__Library_Management_Application_.Models;
using Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces;

namespace Project___ConsoleApp__Library_Management_Application_.Repositories.Implementations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        AppDbContext _dbContext=new AppDbContext();
        public Author GetByIdWithInclude(int id)
        {
            Author author = _dbContext.Authors.Include(x => x.Books).FirstOrDefault(x=>x.Id==id);
            return author;
        }
        public List<Author> GetAllWithInclude()
        {
            return _dbContext.Authors.Include(x=>x.Books).ThenInclude(y=>y.Authors).ToList();
        }

        public void SoftDeleteAuthor(int id)
        {
            var del = _dbContext.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);
            del.IsDeleted = true;
            del.Books.Clear();
            _dbContext.Update(del);
            _dbContext.SaveChanges();
        }

    }
}
