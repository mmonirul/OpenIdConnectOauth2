using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestPay.Access.DAL.Entities.Library;

namespace WestPay.Access.API.Dtos
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }

        public AuthorViewModel Author { get; set; }
    }
}
