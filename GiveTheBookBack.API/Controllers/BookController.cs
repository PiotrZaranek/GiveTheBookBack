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
            var id = _bookService.Add(bookVm);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var result = _bookService.Delete(id);
            if(result == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }            
        }

        [HttpGet("{id}")]
        public ActionResult<BookForDetailsVm> Details(int id)
        {
            var book = _bookService.Details(id);
            if(book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult<ListBookForListVm> GetAll()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }
    }
}
