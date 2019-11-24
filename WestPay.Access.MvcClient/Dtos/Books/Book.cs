using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestPay.Access.MvcClient.Dtos.Books
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
    }
}
