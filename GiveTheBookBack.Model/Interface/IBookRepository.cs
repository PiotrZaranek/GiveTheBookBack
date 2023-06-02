﻿using GiveTheBookBack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Domain.Interface
{
    public interface IBookRepository
    {
        Task<IQueryable<Book>> GetAll();
        Task<int> Add(Book book);
        Task<int> Delete(Book book);
        Task<Book> Get(int id);
    }
}
