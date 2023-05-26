using GiveTheBookBack.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Infrastructure
{
    public class Context : DbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(e => e.Address).WithOne(b => b.User)
                .HasForeignKey<User>(k => k.AddressRef);

            builder.Entity<Transaction>()
                .HasOne(e => e.Book).WithOne(e => e.Transaction)
                .HasForeignKey<Transaction>(k => k.BookRef);
        }        
    }
}
