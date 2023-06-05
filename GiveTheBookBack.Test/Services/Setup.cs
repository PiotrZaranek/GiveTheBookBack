using AutoMapper;
using GiveTheBookBack.Application.Service;
using GiveTheBookBack.Domain.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Services
{
    public static class Setup
    {
        public static BookService CreateBookService() 
        {
            var repo = new Mock<IBookRepository>();
            var mapp = new Mock<IMapper>();
            return new BookService(repo.Object, mapp.Object);
        }
    }
}
