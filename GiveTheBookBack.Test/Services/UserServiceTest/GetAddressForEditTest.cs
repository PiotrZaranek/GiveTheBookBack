using FluentAssertions;
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
    public class GetAddressForEditTest
    {
        [Fact]
        public void GetAddressForEdit_ShouldReturn_AddressForEditVm_WhenExist()
        {
            var repo = new Mock<IUserRepository>();
            var ser = Setup.CreateUserService(repo);
            repo.Setup(m => m.GetAddress(It.IsAny<int>()))
                .Returns(Task.FromResult<Address>(new Address() { City = "abcd" }));

            var result = ser.GetAddressForEdit(It.IsAny<int>());

            result.Should().NotBeNull();
            result.Should().BeOfType<AddressForEditVm>();
            result.City.Should().Be("abcd");
        }

        [Fact]
        public void GetAddressForEdit_ShouldReturn_Null_WhenAddressNotExist()
        {
            var repo = new Mock<IUserRepository>();
            var ser = Setup.CreateUserService(repo);
            repo.Setup(m => m.GetAddress(It.IsAny<int>()))
                .Returns(Task.FromResult<Address>(null));

            var result = ser.GetAddressForEdit(It.IsAny<int>());

            result.Should().BeNull();
        }
    }
}
