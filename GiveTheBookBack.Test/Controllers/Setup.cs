using GiveTheBookBack.API.Controllers;
using GiveTheBookBack.Application.Interface;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Controllers
{
    public static class Setup
    {
        public static UserController CreateUserController(Mock<IUserService> ser)
        {
            var config = new Dictionary<string, string>()
            {
                { "Jwt:Key", "Password" },
                { "Jwt:Issuer", "login.com" }
            };

            IConfiguration con = new ConfigurationBuilder()
                .AddInMemoryCollection(config)
                .Build();

            return new UserController(ser.Object, con);
        }
    }
}
