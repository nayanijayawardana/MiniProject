using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirstDB.IServices;
using CodeFirstDB.ViewModle;
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
            //if (book.ISBN)
            //{
            //    Console.WriteLine(" Already exist");
            //}
            return bookService.AddBook(book);
        }
    }

}
