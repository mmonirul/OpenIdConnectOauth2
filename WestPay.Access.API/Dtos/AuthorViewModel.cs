using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestPay.Access.DAL.Entities.Library;

namespace WestPay.Access.API.Dtos
{
    public class AuthorViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual AuthorBiography Biography { get; set; }
    }
}
