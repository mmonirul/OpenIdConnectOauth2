using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestPay.Access.DAL.Entities.Library
{
    [Table("Publishers")]
    public class Publisher
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
