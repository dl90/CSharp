using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace week_11_preclass_azure.Data
{
    public class Produce
    {
        [Key]
        public int ProduceID { get; set; }
        public string Description { get; set; }

        // Navigation properties.
        // Child.        
        public virtual ICollection<ProduceSupplier> ProduceSuppliers { get; set; }
    }

    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }

        // Navigation properties.
        // Child.
        public virtual ICollection<ProduceSupplier> ProduceSuppliers { get; set; }
    }

    public class ProduceSupplier
    {
        [Key, Column(Order = 0)]
        public int ProduceID { get; set; }
        [Key, Column(Order = 1)]
        public int SupplierID { get; set; }
        public int Qty { get; set; }

        // Navigation properties.
        // Parents.
        public virtual Produce Produce { get; set; }
        public virtual Supplier Supplier { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Define entity collections.
        public DbSet<Produce> Produces { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProduceSupplier> ProduceSuppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define composite primary keys.
            modelBuilder.Entity<ProduceSupplier>()
                .HasKey(ps => new { ps.ProduceID, ps.SupplierID });

            // Define foreign keys here. Do not use foreign key annotations.
            modelBuilder.Entity<ProduceSupplier>()
                .HasOne(p => p.Produce)
                .WithMany(p => p.ProduceSuppliers)
                .HasForeignKey(fk => new { fk.ProduceID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<ProduceSupplier>()
                .HasOne(p => p.Supplier)
                .WithMany(p => p.ProduceSuppliers)
                .HasForeignKey(fk => new { fk.SupplierID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Add seeded data.
            modelBuilder.Entity<Produce>().HasData(
                new Produce { ProduceID = 1, Description = "Oranges" },
                new Produce { ProduceID = 2, Description = "Apples" });

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierID = 1, SupplierName = "Kin's Market" },
                new Supplier { SupplierID = 2, SupplierName = "Fresh Street Market" },
                new Supplier { SupplierID = 3, SupplierName = "Don's Market" });

            modelBuilder.Entity<ProduceSupplier>().HasData(
                new ProduceSupplier { SupplierID = 1, ProduceID = 1, Qty = 25 },
                new ProduceSupplier { SupplierID = 3, ProduceID = 2, Qty = 40 });
        }
    }

}
