using FluentAssertions;
using GiveTheBookBack.API.Controllers;
using GiveTheBookBack.Application.Interface;
using GiveTheBookBack.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Controllers.BookControllerTest
{
    public class GetAllTest
    {
        [Fact]
        public void GetAll_ShouldReturn_Ok200AndListBookForListVm()
        {
            var ser = new Mock<IBookService>();
            var con = new BookController(ser.Object);
            ser.Setup(m => m.GetAll()).Returns(new ListBookForListVm());

            var result = con.GetAll();

            result.Should().BeOfType<OkObjectResult>();
            result.Value.Should().NotBeNull();
            result.Value.Should().BeOfType<ListBookForListVm>();
        }
    }
}
