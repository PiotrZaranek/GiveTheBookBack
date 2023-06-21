using AutoMapper.Configuration.Annotations;
using FluentAssertions;
using GiveTheBookBack.Application.Interface;
using GiveTheBookBack.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Controllers.UserControllerTest
{
    public class LoginTest
    {
        [Fact]
        public void Login_ShouldReturn_Unathorize_WhenEmailOrPasswordIsWrong()
        {
            var ser = new Mock<IUserService>();
            var con = Setup.CreateUserController(ser);
            ser.Setup(m => m.Authenticate(It.IsAny<LoginModel>())).Returns(false);

            var result = con.Login(It.IsAny<LoginModel>());

            result.Should().BeOfType<UnauthorizedResult>();
        }

        [Fact]
        public void Login_ShouldReturn_OkWithToken_WhenEmailAndPasswordIsCorrect()
        {
            var ser = new Mock<IUserService>();
            var con = Setup.CreateUserController(ser);
            ser.Setup(m => m.Authenticate(It.IsAny<LoginModel>())).Returns(true);
            
            var result = con.Login(It.IsAny<LoginModel>());

            result.Should().BeOfType<OkObjectResult>();            
        }
    }
}
