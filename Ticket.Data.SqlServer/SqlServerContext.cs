using Microsoft.EntityFrameworkCore;
using Ticket.Data.Context;

namespace Ticket.Data.SqlServer
{
    public class SqlServerContext : TicketDbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }
    }
}