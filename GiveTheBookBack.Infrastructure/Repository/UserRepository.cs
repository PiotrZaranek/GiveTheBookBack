using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly private Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAddress(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Authenticate(LoginModel loginModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Mail == loginModel.Mail);

            if(user != null)
            {
                if(user.Password == loginModel.Password)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task EditAddress(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task<Address> GetAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            return address;
        }

        public async Task<bool> IsUserExist(User user)
        {
            return await _context.Users.AnyAsync(u => u.Mail == user.Mail);
        }

        public async Task Registration(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
