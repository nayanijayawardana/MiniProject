using CodeFirstDB.ViewModle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstDB.IServices
{
    public interface IBookService
    {
        IEnumerable<Book> GetBook();

        Book AddBook(Book book);

        Book DeleteBook(string isbn);
    }
}
