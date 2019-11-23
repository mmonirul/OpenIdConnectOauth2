using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestPay.Access.API.Services.Interfaces;
using WestPay.Access.DAL.Entities.Library;

namespace WestPay.Access.API.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book> AddAsync(Book book)
        {
            try
            {
                var addedBook = await _unitOfWork.Books.Create(book).ConfigureAwait(false);
                await _unitOfWork.CommitAsync();

                return addedBook;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _unitOfWork.Books.GetAsync();
        }
        public async Task<IEnumerable<Book>> GetBooksIncludingAuthorAsync()
        {
            return await _unitOfWork.Books.GetAsync(null, x => x.Author);
        }

        public Task<Book> GetBookByIdAsync(int id)
        {
            return _unitOfWork.Books.GetByIdAsync(id);
        }

        public void Remove(Book bookToDelete)
        {
            _unitOfWork.Books.Delete(bookToDelete);
            _unitOfWork.Commit();
        }

        public async Task<Book> UpdateAsync(Book model)
        {
            _unitOfWork.Books.Update(model);

            try
            {
                await _unitOfWork.CommitAsync();
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}
