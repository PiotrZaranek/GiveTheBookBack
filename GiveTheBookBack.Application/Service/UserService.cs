using GiveTheBookBack.Application.Interface;
using GiveTheBookBack.Application.ViewModel;
using GiveTheBookBack.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Application.Service
{
    public class UserService : IUserService
    {
        readonly private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void AddAddress(NewAddressVm addressVm)
        {
            throw new NotImplementedException();
        }

        public bool Authenticate(LoginUserVm loginModel)
        {
            throw new NotImplementedException();
        }

        public void EditAddress(AddressForEditVm addressVm)
        {
            throw new NotImplementedException();
        }

        public AddressForEditVm GetAddressForEdit(int id)
        {
            throw new NotImplementedException();
        }

        public void Registration(NewUserVm userVm)
        {
            throw new NotImplementedException();
        }
    }
}
