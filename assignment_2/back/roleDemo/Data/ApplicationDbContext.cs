using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using roleDemo.Models;

namespace roleDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attendee>()
                .HasKey(a => new { a.EventId, a.UserId });

            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.Event)
                .WithMany(a => a.Attendees)
                .HasForeignKey(fk => new { fk.EventId })
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.User)
                .WithMany(a => a.Attendees)
                .HasForeignKey(fk => new { fk.UserId })
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
