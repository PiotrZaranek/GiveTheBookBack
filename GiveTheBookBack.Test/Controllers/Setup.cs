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
            var con = new Mock<IConfiguration>();
            return new UserController(ser.Object, con.Object);
        }
    }
}
