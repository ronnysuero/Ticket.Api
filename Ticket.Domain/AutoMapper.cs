using AutoMapper;
using Ticket.Domain.Models;

namespace Ticket.Domain
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Data.Entities.Ticket, TicketModel>().ReverseMap();
        }
    }
}