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
    public class GetAllTest
    {
        [Fact]
        public void GetAll_ShouldReturn_ListBookForListVm()
        {
            var repo = new Mock<IBookRepository>();
            var ser = Setup.CreateBookService(repo);
            repo.Setup(m => m.GetAll())
                .Returns(Task.FromResult<List<Book>>(new List<Book>()));

            var result = ser.GetAll();

            result.Should().NotBeNull();
            Assert.IsType<ListBookForListVm>(result);            
        }

        [Fact]
        public void GetAll_ReturnValue_ElementBookList_ShouldBe_BookForListVm()
        {            
            var repo = new Mock<IBookRepository>();
            var ser = Setup.CreateBookService(repo);
            repo.Setup(m => m.GetAll())
                .Returns(Task.FromResult<List<Book>>(new List<Book>()));

            var result = ser.GetAll();

            result.BookList.Should().NotBeNull();
            Assert.IsType<List<BookForListVm>>(result.BookList);
        }
    }
}
