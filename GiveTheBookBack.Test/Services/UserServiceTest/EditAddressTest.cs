using GiveTheBookBack.Application.ViewModel;
using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Domain.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Services.UserServiceTest
{
    public class EditAddressTest
    {
        [Fact]
        public void EditAddress_ShouldInvoke_UserRepositoryEditAddress()
        {
            var repo = new Mock<IUserRepository>();
            var ser = Setup.CreateUserService(repo);

            ser.EditAddress(It.IsAny<AddressForEditVm>());

            repo.Verify(m => m.EditAddress(It.IsAny<Address>()), Times.Once);
        }
    }
}
