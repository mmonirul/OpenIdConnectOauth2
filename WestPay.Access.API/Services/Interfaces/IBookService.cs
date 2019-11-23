using System.Collections.Generic;
using System.Threading.Tasks;
using WestPay.Access.DAL.Entities.Library;

namespace WestPay.Access.API.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book model);
        void Remove(Book bookToDelete);
    }
}