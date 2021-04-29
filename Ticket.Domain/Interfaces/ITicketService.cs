using System.Collections.Generic;
using System.Threading.Tasks;
using Ticket.Domain.Models;

namespace Ticket.Domain.Interfaces
{
    public interface ITicketService
    {
        Task<TicketModel> Insert(TicketModel model);
        Task<TicketModel> Update(TicketModel model);
        Task<bool> Delete(int id);
        Task<TicketModel> GetById(int id);
        Task<IEnumerable<TicketModel>> GetAll();

    }
}