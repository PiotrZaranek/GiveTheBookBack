using AutoMapper;
using GiveTheBookBack.Application.Interface;
using GiveTheBookBack.Application.ViewModel;
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

        public bool Authenticate(LoginUserVm loginModel)
        {
            throw new NotImplementedException();
        }

        public void EditAddress(AddressForEditVm addressVm)
        {
            var address = _mapper.Map<Address>(addressVm);
            _repository.EditAddress(address);
        }

        public AddressForEditVm GetAddressForEdit(int id)
        {
            var address = _repository.GetAddress(id);

            if(address != null)
            {
                return _mapper.Map<AddressForEditVm>(address);
            }            
            else
            {
                return null;
            }
        }

        public void Registration(NewUserVm userVm)
        {
            var user = _mapper.Map<User>(userVm);
            _repository.Registration(user);
        }
    }
}
