﻿using GiveTheBookBack.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Application.Interface
{
    public interface IUserService
    {
        bool Authenticate(LoginUserVm loginModel);
        void Registration(NewUserVm userVm);
        void AddAddress(NewAddressVm addressVm);
        AddressForEditVm GetAddressForEdit(int id);
        void EditAddress(AddressForEditVm addressVm);
    }
}