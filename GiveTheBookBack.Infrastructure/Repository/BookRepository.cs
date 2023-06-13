using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace GiveTheBookBack.Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _context;

        public BookRepository(Context context) 
        {
            _context = context;            
        }

        public async Task<int> Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int> Delete(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<Book> Get(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<List<Book>> GetAll()
        {
            return await GetAllActiveBooks().ToListAsync();
        }

        public async Task<List<Book>> GetBooksByUserId(int userId)
        {
            return await GetAllUserBooks(userId).ToListAsync();
        }

        private IQueryable<Book> GetAllActiveBooks() 
        {
            return _context.Books.Where(b => b.IsActive == true);
        }

        private IQueryable<Book> GetAllUserBooks(int userId)
        {
            return _context.Books.Where(a => a.UserRef == userId);
        }
    }
}