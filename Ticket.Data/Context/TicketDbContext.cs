using Microsoft.EntityFrameworkCore;

namespace Ticket.Data.Context
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Ticket>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(k => k.Id).ValueGeneratedOnAdd();
                entity.Property(ug => ug.Username).IsRequired().HasMaxLength(50);
            });
        }
    }
}