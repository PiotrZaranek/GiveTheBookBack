using FluentAssertions;
using GiveTheBookBack.API.Controllers;
using GiveTheBookBack.Application.Interface;
using GiveTheBookBack.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Controllers.BookControllerTest
{
    public class DetailsTest
    {
        [Fact]
        public void Details_ShouldReturn_OK200AndBookForDetails_WhenBookExist()
        {
            var ser = new Mock<IBookService>();
            var con = new BookController(ser.Object);
            ser.Setup(m => m.Details(It.IsAny<int>())).Returns(new BookForDetailsVm() { Title = "abcd"});

            var result = con.Details(It.IsAny<int>());

            result.Should().BeOfType<ActionResult<BookForDetailsVm>>();
            result.Result.Should().BeOfType<OkObjectResult>();            
        }

        [Fact]
        public void Details_ShouldReturn_404NotFound_WhenBookNotExist()
        {
            var ser = new Mock<IBookService>();
            var con = new BookController(ser.Object);
            ser.Setup(m => m.Details(It.IsAny<int>())).Returns(value: null);

            var result = con.Details(It.IsAny<int>());

            result.Should().BeOfType<ActionResult<BookForDetailsVm>>();
            result.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}
