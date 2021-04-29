using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ticket.Data.Context;
using Ticket.Data.Extensions;
using Ticket.Data.Interfaces;
using Ticket.Data.SqlServer;

namespace Ticket.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreDataProvider<TDbContext, TDbFactory>(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> optionsActions
        )
            where TDbContext : TicketDbContext
            where TDbFactory : IDbFactory
        {
            services.AddDataProvider<TDbContext, TDbFactory>(optionsActions);

            services.AddScoped(typeof(IDbFactory), typeof(TDbFactory));

            return services;
        }

        public static IServiceCollection AddCoreSqlDataProvider(
            this IServiceCollection services,
            string connectionString
        )
        {
            services.AddCoreDataProvider<SqlServerContext, SqlServerFactory>(
                builder => builder.UseSqlServer(connectionString)
            );

            return services;
        }
    }
}