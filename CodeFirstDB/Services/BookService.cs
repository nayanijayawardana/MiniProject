using CodeFirstDB.DataLayer;
using CodeFirstDB.IServices;
using CodeFirstDB.ViewModle;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (book != null)
            {
                dbcontext.Books.Add(book);
                dbcontext.SaveChanges();
                return book;
            }

            //if (book.ISBN)
            //{
            //    Console.WriteLine(" Already exist");
            //}

            //if (VotingDbContext.Book.Any(o => o.Id == idToMatch))
            //{
            //    // Match!
            //}
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
