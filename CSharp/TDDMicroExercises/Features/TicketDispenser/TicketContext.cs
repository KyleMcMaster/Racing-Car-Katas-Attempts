using Microsoft.EntityFrameworkCore;

namespace TDDMicroExercises.Features.TicketDispenser
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TurnTicket> Tickets { get; set; }
    }
}
