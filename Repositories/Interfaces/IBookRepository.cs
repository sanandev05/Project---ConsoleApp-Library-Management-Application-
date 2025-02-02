﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project___ConsoleApp__Library_Management_Application_.Models;

namespace Project___ConsoleApp__Library_Management_Application_.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public void Create(Book entity);
        public void Delete(Book entity);
        Book GetById(int id);
        List<Book> GetAll();
        int Commit();
    }
}
