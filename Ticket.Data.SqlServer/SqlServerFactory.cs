using Ticket.Data.Context;
using Ticket.Data.Interfaces;

namespace Ticket.Data.SqlServer
{
    public class SqlServerFactory : IDbFactory
    {
        private readonly SqlServerContext _db;

        public SqlServerFactory(SqlServerContext db)
        {
            _db = db;
        }

        public TicketDbContext Db => _db;
    }
}