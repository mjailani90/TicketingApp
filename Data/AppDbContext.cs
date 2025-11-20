

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketingApp.Models;

namespace TicketingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EventItem> Events { get; set; }

        public DbSet<Ticket> Ticket { get; set; }


    }
}
