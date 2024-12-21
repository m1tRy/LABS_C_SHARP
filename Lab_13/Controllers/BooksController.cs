using Lab_13.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_13.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class BooksController : ControllerBase
    {
        BooksContext DB;
        public BooksController(BooksContext context)
        {
            DB = context;
           
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return DB.Books.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            Book? book = DB.Books.FirstOrDefault(x => x.BookID == id);
            if (book == null)
            {
                return NotFound();
            }
            return new ObjectResult(book);
        }

        [HttpPost]
        public ActionResult<Book> Post(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            DB.Books.Add(book);
            DB.SaveChanges();
            return Ok(book);

        }

        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            Book? book = DB.Books.FirstOrDefault(x => x.BookID == id);
            if (book == null)
            {
                return NotFound();
            }
            DB.Books.Remove(book);
            DB.SaveChanges();
            return Ok(book);
        }
    }
}
