using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestPay.Access.DAL.Entities.Library;
using WestPay.Access.DAL.Repositories;

namespace WestPay.Access.API.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Book> Books { get; }

        void Commit();
        Task<int> CommitAsync();
    }
}
