using AutoMapper;
using GiveTheBookBack.Application.Mapper;
using GiveTheBookBack.Application.Service;
using GiveTheBookBack.Domain.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace GiveTheBookBack.Test.Services
{
    public static class Setup
    {
        public static UserService CreateUserService(Mock<IUserRepository> repo) 
        { 
            return new UserService(repo.Object, AddMapper());
        }

        public static BookService CreateBookService(Mock<IBookRepository> repo) 
        {                       
            return new BookService(repo.Object, AddMapper());
        }

        public static Mapper AddMapper()
        {            
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            return new Mapper(configuration);
        }
    }
}
