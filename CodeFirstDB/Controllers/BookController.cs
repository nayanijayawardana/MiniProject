using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirstDB.IServices;
using CodeFirstDB.ViewModle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xceed.Wpf.Toolkit;

namespace CodeFirstDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService book)
        {
            bookService = book;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        [Route("api/Book/GetBook")]
        public IEnumerable<Book> GetBook()
        {
            return bookService.GetBook();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Book/AddBook")]

        public Book AddBook(Book book)
        {
            try
            {
                return bookService.AddBook(book);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [Authorize]
        [HttpDelete]
        [Route("[action]")]
        [Route("api/Book/DeleteBook")]

        public Book DeleteBook(string isbn)
        {
            return bookService.DeleteBook(isbn);
        }
    }

}
