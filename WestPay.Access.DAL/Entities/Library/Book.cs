using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestPay.Access.DAL.Entities.Library
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }
        
        [Required]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public virtual Publisher Publisher { get; set; }
        public Guid PublisherId { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
