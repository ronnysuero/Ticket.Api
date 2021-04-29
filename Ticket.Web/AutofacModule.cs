using Autofac;
using Ticket.Data.Interfaces;
using Ticket.Domain.Interfaces;

namespace Ticket.Web
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ITicketService).Assembly, typeof(IUnitOfWork).Assembly)
                .Where(t => t.Name.EndsWith("Service") || t.Name.Equals("UnitOfWork"))
                .AsImplementedInterfaces();
        }
    }
}