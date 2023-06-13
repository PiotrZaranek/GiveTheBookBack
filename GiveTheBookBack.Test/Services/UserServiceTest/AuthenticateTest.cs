using FluentAssertions;
using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Domain.Model;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Services.UserServiceTest
{
    public class AuthenticateTest
    {
        [Fact]
        public void Authenticate_ShouldReturn_False_WhenUserRepositoryAuthenticate_ReturnFalse()
        {
            var repo = new Mock<IUserRepository>();
            var ser = Setup.CreateUserService(repo);
            repo.Setup(m => m.Authenticate(It.IsAny<LoginModel>()))
                .Returns(Task<bool>.FromResult(false));

            var result = ser.Authenticate(It.IsAny<LoginModel>());

            result.Should().Be(false);
        }

        [Fact]
        public void Authenticate_ShouldReturn_True_WhenUserRepositoryAuthenticate_ReturnTrue()
        {
            var repo = new Mock<IUserRepository>();
            var ser = Setup.CreateUserService(repo);
            repo.Setup(m => m.Authenticate(It.IsAny<LoginModel>()))
                .Returns(Task<bool>.FromResult(true));

            var result = ser.Authenticate(It.IsAny<LoginModel>());

            result.Should().Be(true);
        }
    }
}
