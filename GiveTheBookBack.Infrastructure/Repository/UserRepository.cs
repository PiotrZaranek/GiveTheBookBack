using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task AddAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAddress(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserExist(User user)
        {
            throw new NotImplementedException();
        }

        public Task Registration(User user)
        {
            throw new NotImplementedException();
        }
    }
}
