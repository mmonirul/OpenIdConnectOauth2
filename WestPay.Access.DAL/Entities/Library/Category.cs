using System.Collections.Generic;

namespace WestPay.Access.DAL.Entities.Library
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}
