using AutoMapper;
using FluentAssertions;
using GiveTheBookBack.Application.Service;
using GiveTheBookBack.Application.ViewModel;
using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Domain.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Services.BookServicesTest
{    
    public class AddTest
    {
        [Fact]
        public void Add_ShouldInvoke_BookRepositoryAdd()
        {
            var repo = new Mock<IBookRepository>();            
            var ser = Setup.CreateBookService(repo);
            
            var result = ser.Add(It.IsAny<NewBookVm>());

            repo.Verify(m => m.Add(It.IsAny<Book>()), Times.Once());
        }

        [Fact]
        public void AddReturnType_ShouldBe_Int()
        {
            var repo = new Mock<IBookRepository>();
            var ser = Setup.CreateBookService(repo);
            repo.Setup(m => m.Add(It.IsAny<Book>())).Returns(Task<int>.FromResult(1));

            var result = ser.Add(It.IsAny<NewBookVm>());
            
            Assert.IsType<int>(result);
            result.Should().Be(1);            
        }
    }
}
