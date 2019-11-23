using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestPay.Access.DAL.Database;
using WestPay.Access.DAL.Entities.Library;

namespace WestPay.Access.API.Data
{
    public class DBInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Books.Any())
            {
                var author = new Author
                {
                    Id = 1,
                    FirstName = "William",
                    LastName = "Shakespeare"
                };

                context.Authors.Add(author);

                var publisher = new Publisher
                {
                    Name = "BBC Books"
                };
                context.Publishers.Add(publisher);

                var books = new List<Book>{
                    new Book { Id = 1, AuthorId = 1, PublisherId = publisher.Id, Title = "Hamlet", ISBN = "978-91-7000-150-5" },
                    new Book { Id = 2, AuthorId = 1, PublisherId = publisher.Id, Title = "King Lear", ISBN = "978-91-7000-150-15" },
                    new Book { Id = 3, AuthorId = 1, PublisherId = publisher.Id, Title = "Othello", ISBN = "978-91-7000-100-0" }
                };

                context.AddRange(books);

                context.SaveChanges();

            }
        }
    }
}
