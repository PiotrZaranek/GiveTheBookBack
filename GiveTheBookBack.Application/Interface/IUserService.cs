using GiveTheBookBack.Application.ViewModel;
using GiveTheBookBack.Domain.Model;
using GiveTheBookBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Application.Interface
{
    public interface IUserService
    {
        bool Authenticate(LoginModel loginModel);
        RegistrationResultEnum.RegistrationResult Registration(NewUserVm userVm);
        void AddAddress(NewAddressVm addressVm);
        AddressForEditVm GetAddressForEdit(int id);
        void EditAddress(AddressForEditVm addressVm);
    }
}
