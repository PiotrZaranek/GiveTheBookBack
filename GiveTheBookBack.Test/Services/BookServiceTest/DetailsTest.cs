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

namespace GiveTheBookBack.Test.Services.BookServiceTest
{
    public class DetailsTest
    {
        [Fact]
        public void Details_ShouldInvoke_BookRepositoryGet()
        {
            var repo = new Mock<IBookRepository>();
            var ser = Setup.CreateBookService(repo);

            ser.Details(It.IsAny<int>());

            repo.Verify(m => m.Get(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Details_ShouldReturn_BookForDetailsVm_IfBookExist()
        {
            var repo = new Mock<IBookRepository>();
            var ser = Setup.CreateBookService(repo);
            repo.Setup(m => m.Get(It.IsAny<int>()))
                .Returns(Task.FromResult<Book>(new Book() { Title = "abcd" }));

            var result = ser.Details(It.IsAny<int>());

            result.Should().NotBeNull();
            Assert.IsType<BookForDetailsVm>(result);
            result.Title.Should().Be("abcd");
        }

        [Fact]
        public void Details_ShouldReturn_Null_IfBookNotExist()
        {
            var repo = new Mock<IBookRepository>();
            var ser = Setup.CreateBookService(repo);
            repo.Setup(m => m.Get(It.IsAny<int>())).Returns(Task.FromResult<Book>(null));

            var result = ser.Details(It.IsAny<int>());

            result.Should().BeNull();
        }
    }
}
