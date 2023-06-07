using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GiveTheBookBack.Application.ViewModel;
using GiveTheBookBack.Application.Interface;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace GiveTheBookBack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult Add(NewBookVm bookVm)
        {
            return Ok("Add");
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            return Ok("Delete");
        }

        [HttpGet("{id}")]
        public ActionResult<BookForDetailsVm> Details()
        {
            return Ok("Details");
        }

        [HttpGet]
        public ActionResult<ListBookForListVm> GetAll()
        {
            return Ok("GetAll");
        }
    }
}
