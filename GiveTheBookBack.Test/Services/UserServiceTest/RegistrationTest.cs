using FluentAssertions;
using GiveTheBookBack.Application.ViewModel;
using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Domain.Model;
using GiveTheBookBack.Domain.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Services.UserServiceTest
{
    public class RegistrationTest
    {
        [Fact]
        public void Registration_ShouldReturn_UserAdded_WhenRegistrationEndsSuccess()
        {
            var repo = new Mock<IUserRepository>();
            var ser = Setup.CreateUserService(repo);
            repo.Setup(m => m.IsUserExist(It.IsAny<User>()))
                .Returns(Task.FromResult(false));

            var result = ser.Registration(It.IsAny<NewUserVm>());

            result.Should().Be(RegistrationResult.UserAdded);
        }

        [Fact]
        public void Registration_ShouldReturn_UserExist_WhenRegistrationEndsFailure()
        {
            var repo = new Mock<IUserRepository>();
            var ser = Setup.CreateUserService(repo);
            repo.Setup(m => m.IsUserExist(It.IsAny<User>()))
                .Returns(Task.FromResult(true));

            var result = ser.Registration(It.IsAny<NewUserVm>());

            result.Should().Be(RegistrationResult.UserExist);
        }
    }
}
