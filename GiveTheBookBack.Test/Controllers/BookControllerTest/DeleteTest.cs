using FluentAssertions;
using GiveTheBookBack.API.Controllers;
using GiveTheBookBack.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiveTheBookBack.Test.Controllers.BookControllerTest
{
    public class DeleteTest
    {
        [Fact]
        public void Delete_ShouldReturn_OK200_IfBookWasDeletedSuccessfull()
        {
            var ser = new Mock<IBookService>();
            var con = new BookController(ser.Object);
            ser.Setup(m => m.Delete(It.IsAny<int>())).Returns(1);

            var result = con.Delete(It.IsAny<int>());

            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void Delete_ShouldReturn_NotFound404_IfBookNotExist()
        {
            var ser = new Mock<IBookService>();
            var con = new BookController(ser.Object);
            ser.Setup(m => m.Delete(It.IsAny<int>())).Returns(0);
            
            var result = con.Delete(It.IsAny<int>());

            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
