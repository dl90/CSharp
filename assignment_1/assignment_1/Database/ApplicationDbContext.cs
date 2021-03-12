using assignment_1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace assignment_1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<ClientAccount> ClientAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClientAccount>()
                .HasKey(ca => new { ca.ClientID, ca.AccountNum });

            modelBuilder.Entity<ClientAccount>()
                .HasOne(ca => ca.Client)
                .WithMany(ca => ca.ClientAccounts)
                .HasForeignKey(fk => new { fk.ClientID })
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClientAccount>()
                .HasOne(ca => ca.BankAccount)
                .WithMany(ca => ca.ClientAccounts)
                .HasForeignKey(fk => new { fk.AccountNum })
                .OnDelete(DeleteBehavior.Restrict);

            // seed
            /*
            modelBuilder.Entity<Client>().HasData(
                new Client { ClientID = 1, Email = "test1@test.com", FirstName = "John", LastName = "Doe" },
                new Client { ClientID = 2, Email = "test2@test.com", FirstName = "Jane", LastName = "Doe" });

            modelBuilder.Entity<BankAccount>().HasData(
                new BankAccount { AccountNum = 1002, AccountType = "Checking", Balance = 200 },
                new BankAccount { AccountNum = 1003, AccountType = "Savings", Balance = 300 },
                new BankAccount { AccountNum = 1004, AccountType = "Savings", Balance = 400 });

            modelBuilder.Entity<ClientAccount>().HasData(
                new ClientAccount { ClientID = 1, AccountNum = 1002 },
                new ClientAccount { ClientID = 2, AccountNum = 1003 },
                new ClientAccount { ClientID = 2, AccountNum = 1004 });
            */
        }
    }
}
