using AutoMapper;
using FluentAssertions;
using GiveTheBookBack.Application.Service;
using GiveTheBookBack.Domain.Interface;
using GiveTheBookBack.Domain.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Services.BookServiceTest
{
    public class DeleteTest
    {
        [Fact]
        public void Delete_SouldInvoke_BookRepositoryGet()
        {
            var repo = new Mock<IBookRepository>();
            var ser = Setup.CreateBookService(repo);

            ser.Delete(It.IsAny<int>());

            repo.Verify(m => m.Get(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Delete_ShouldInvoke_BookRepositoryDelete_IfBookExistAndRetunrBookId()
        {
            var repo = new Mock<IBookRepository>();
            var ser = Setup.CreateBookService(repo);
            repo.Setup(m => m.Get(It.IsAny<int>())).Returns(Task<Book>.FromResult(new Book()));
            repo.Setup(m => m.Delete(It.IsAny<Book>())).Returns(Task<int>.FromResult(1));

            var result = ser.Delete(It.IsAny<int>());

            repo.Verify(m => m.Delete(It.IsAny<Book>()), Times.Once);
            Assert.IsType<int>(result);
            result.Should().Be(1);
        }

        [Fact]
        public void Delete_ShouldReturn_0_WhenBookNotExist()
        {
            var repo = new Mock<IBookRepository>();
            var ser = Setup.CreateBookService(repo);
            repo.Setup(m => m.Get(It.IsAny<int>())).Returns(Task.FromResult<Book>(null));

            var result = ser.Delete(It.IsAny<int>());

            Assert.IsType<int>(result);
            result.Should().Be(0);
        }


    }
}
