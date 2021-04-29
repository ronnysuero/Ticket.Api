using System;
using System.Threading.Tasks;
using Ticket.Data.Context;
using Ticket.Data.Interfaces;

namespace Ticket.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IDbFactory factory)
        {
            _db = factory.Db;
        }

        private readonly TicketDbContext _db;
        private IRepository<Entities.Ticket> _ticketRepository;


        public IRepository<Entities.Ticket> Ticket
        {
            get
            {
                _ticketRepository ??= new Repository<Entities.Ticket>(_db);

                return _ticketRepository;
            }
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}