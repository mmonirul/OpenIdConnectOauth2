using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestPay.Access.MvcClient.Dtos.Books
{
    public class BookIndexViewModel
    {
        public IEnumerable<Book> Books { get; private set; }
            = new List<Book>();

        public BookIndexViewModel(List<Book> books)
        {
            Books = books;
        }
    }
}
