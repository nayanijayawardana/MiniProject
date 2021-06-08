using Azure.Core;
using CodeFirstDB.DataLayer;
using CodeFirstDB.IServices;
using CodeFirstDB.ViewModle;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodeFirstDB.Services
{
    public class BookService : IBookService
    {
        VotingDbContext dbcontext;

        public BookService(VotingDbContext _db)
        {
            dbcontext = _db;
        }

        public IEnumerable<Book> GetBook()
        {
            var book = dbcontext.Books.ToList();
            return book;

        }


        public Book AddBook(Book book)
        {

            var validation = dbcontext.Books.Any(o => o.ISBN == book.ISBN);
            if (validation == true)
            {
                throw new HttpRequestException("This is already included");
            }
            //var valid = dbcontext.Books.FirstOrDefault(x => x.ISBN == book.ISBN);
            //if (valid != null)
            //{
            //    throw new Exception("This is already included");
            //    throw new InvalidOperationException("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            //}

            else if (book != null)
            {
                dbcontext.Books.Add(book);
                dbcontext.SaveChanges();
                return book;
            }
            return null;
        }




        public Book DeleteBook(string isbn)
        {
            var book = dbcontext.Books.FirstOrDefault(x => x.ISBN == isbn);
            dbcontext.Entry(book).State = EntityState.Deleted;
            dbcontext.SaveChanges();
            return book;
        }
    }

}
