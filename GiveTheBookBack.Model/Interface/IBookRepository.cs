using GiveTheBookBack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Domain.Interface
{
    internal interface IBookRepository
    {
        IQueryable<Book> GetAll();
        int Add(Book book);
        int Delete(Book book);
        Book Get(int id);
    }
}
