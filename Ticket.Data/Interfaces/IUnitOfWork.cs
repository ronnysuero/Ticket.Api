using System;
using System.Threading.Tasks;

namespace Ticket.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Entities.Ticket> Ticket { get; }
        int Save();

        Task<int> SaveAsync();
    }
}