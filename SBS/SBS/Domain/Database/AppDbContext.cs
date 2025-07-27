//// Ignore Spelling: Accessor

using Microsoft.EntityFrameworkCore;
using SBS.Domain.ContextEntension;
using SBS.Domain.Entities;

namespace SBS.Domain.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Call the extension method to seed data
            builder.Seeds();
        }

        //Add DbSet for each entity
        public DbSet<Studio> studios { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
