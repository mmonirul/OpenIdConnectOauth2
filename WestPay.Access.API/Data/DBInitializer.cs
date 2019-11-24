using Microsoft.EntityFrameworkCore;
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

            context.Database.Migrate();

            if (!context.Books.Any())
            {
                var author1 = new Author
                {
                    Id = new Guid("b7539694-97e7-4dfe-84da-b4256e1ff5c7"),
                    FirstName = "Erik",
                    LastName = "Nilsson"
                };
                context.Authors.Add(author1);
                var author2 = new Author
                {
                    Id = new Guid("d860efca-22d9-47fd-8249-791ba61b07c7"),
                    FirstName = "Markus",
                    LastName = "Olsson"
                };
                context.Authors.Add(author2);

                var publisher = new Publisher
                {
                    Name = "BBC Books"
                };
                context.Publishers.Add(publisher);

                var books = new List<Book>{
                    new Book { Id = 1, AuthorId = author1.Id, PublisherId = publisher.Id, Title = "Hamlet", ISBN = "978-91-7000-150-5" },
                    new Book { Id = 2, AuthorId =  author1.Id, PublisherId = publisher.Id, Title = "King Lear", ISBN = "978-91-7000-150-15" },
                    new Book { Id = 3, AuthorId = author2.Id, PublisherId = publisher.Id, Title = "Othello", ISBN = "978-91-7000-100-0" }
                };

                context.AddRange(books);

                context.SaveChanges();

            }
        }
    }
}
