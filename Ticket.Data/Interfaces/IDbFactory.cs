using Ticket.Data.Context;

namespace Ticket.Data.Interfaces
{
    public interface IDbFactory
    {
        TicketDbContext Db { get; }
    }
}