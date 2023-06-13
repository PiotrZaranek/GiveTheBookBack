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
    public class AddAddressTest
    {
        [Fact]
        public void AddAddress_ShouldInvoked_UserRepositoryAddAddress()
        {
            var repo = new Mock<IUserRepository>();
            var ser = Setup.CreateUserService(repo);

            ser.AddAddress(It.IsAny<NewAddressVm>());

            repo.Verify(m => m.AddAddress(It.IsAny<Address>()), Times.Once());
        }
    }
}
