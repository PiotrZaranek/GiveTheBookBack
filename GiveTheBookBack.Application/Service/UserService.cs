using AutoMapper;
using GiveTheBookBack.Application.Interface;
using GiveTheBookBack.Application.ViewModel;
using GiveTheBookBack.Domain.Enums;
using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Domain.Model;
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
        readonly private IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddAddress(NewAddressVm addressVm)
        {
            var address = _mapper.Map<Address>(addressVm);
            _repository.AddAddress(address);
        }

        public bool Authenticate(LoginModel loginModel)
        {
            return _repository.Authenticate(loginModel).Result;
        }

        public void EditAddress(AddressForEditVm addressVm)
        {
            var address = _mapper.Map<Address>(addressVm);
            _repository.EditAddress(address);
        }

        public AddressForEditVm GetAddressForEdit(int id)
        {
            var address = _repository.GetAddress(id).Result;

            if(address != null)
            {
                return _mapper.Map<AddressForEditVm>(address);
            }            
            else
            {
                return null;
            }
        }

        public RegistrationResult Registration(NewUserVm userVm)
        {
            var user = _mapper.Map<User>(userVm);

            if(_repository.IsUserExist(user).Result)
            {
                return RegistrationResult.UserExist;
            }
            else
            {
                _repository.Registration(user);
                return RegistrationResult.UserAdded;
            }            
        }
    }
}
