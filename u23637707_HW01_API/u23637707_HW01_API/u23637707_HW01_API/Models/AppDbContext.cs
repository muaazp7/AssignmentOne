using Microsoft.EntityFrameworkCore;

namespace u23637707_HW01_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Event_Id = Guid.Parse("b7f9e2a1-3c45-4d67-8f90-123456789abc"),
                    Title = "SRC",
                    Location = "HB",
                    TicketPricing = 50
                }
            );
        }
    }
}
