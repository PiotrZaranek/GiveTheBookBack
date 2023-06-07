using GiveTheBookBack.Application.Interface;
using GiveTheBookBack.API.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiveTheBookBack.Application.ViewModel;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace GiveTheBookBack.Test.Controllers.BookControllerTest
{
    public class AddTest
    {
        [Fact]
        public void Add_ShouldReturn_Ok200_IfBookWasSuccesfullAdded()
        {
            var ser = new Mock<IBookService>();
            var con = new BookController(ser.Object);
            ser.Setup(m => m.Add(It.IsAny<NewBookVm>())).Returns(1);

            var result = con.Add(It.IsAny<NewBookVm>());

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
