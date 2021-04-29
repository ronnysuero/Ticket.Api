using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ticket.Data.Context;
using Ticket.Data.Interfaces;

namespace Ticket.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataProvider<TDbContext, TDbFactory>(
            this IServiceCollection service, Action<DbContextOptionsBuilder> optionsActions)
            where TDbContext : TicketDbContext
            where TDbFactory : IDbFactory

        {
            service.AddDbContext<TDbContext>(optionsActions);
            service.AddScoped(typeof(IDbFactory), typeof(TDbFactory));
            return service;
        }
    }
}