using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ticket.Data.SqlServer
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SqlServerContext>();

            builder.UseSqlServer(GetConnectionString());
            builder.EnableSensitiveDataLogging();

            return new SqlServerContext(builder.Options);
        }


        private string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.release.json", true, true)
                .AddJsonFile($"appsettings.json", true, true)
                .Build();

            return configuration.GetConnectionString("Local");
        }
    }
}