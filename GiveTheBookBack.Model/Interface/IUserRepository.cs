using GiveTheBookBack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Domain.Interface
{
    public interface IUserRepository
    {
        Task Registration(User user);
        Task<bool> IsUserExist(User user);
        Task AddAddress(Address address);
        Task<Address> GetAddress(int id);
        Task EditAddress(Address address);
    }
}
