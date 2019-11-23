using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestPay.Access.API.Services.Interfaces;
using WestPay.Access.DAL.Database;
using WestPay.Access.DAL.Entities.Library;
using WestPay.Access.DAL.Repositories;

namespace WestPay.Access.API.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private BaseRepository<Book> _books;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<Book> Books
        {
            get
            {
                return _books ?? (_books = new BaseRepository<Book>(_context));
            }
        }


        public void Commit()
        {
            _context.SaveChanges();
        }
        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
