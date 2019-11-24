using System;

namespace WestPay.Access.DAL.Entities.Library
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual AuthorBiography Biography { get; set; }
    }
}