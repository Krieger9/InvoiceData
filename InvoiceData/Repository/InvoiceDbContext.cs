using InvoiceData.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceData.Repository
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Invoice entity
            modelBuilder.Entity<Invoice>()
                .HasKey(i => i.InvoiceNumber);

            modelBuilder.Entity<Invoice>()
                .OwnsOne(i => i.BillTo, b =>
                {
                    b.Property(c => c.Name).HasColumnName("BillTo_Name").IsRequired();
                    b.Property(c => c.Address).HasColumnName("BillTo_Address");
                    b.Property(c => c.City).HasColumnName("BillTo_City");
                    b.Property(c => c.State).HasColumnName("BillTo_State");
                    b.Property(c => c.ZipCode).HasColumnName("BillTo_ZipCode");
                    b.Property(c => c.Phone).HasColumnName("BillTo_Phone");
                    b.Property(c => c.Email).HasColumnName("BillTo_Email");
                });

            modelBuilder.Entity<Invoice>()
                .OwnsMany(i => i.Items, a =>
                {
                    a.WithOwner().HasForeignKey("InvoiceId");
                    a.HasKey("InvoiceId", "Description", "Amount");
                    a.Property(ii => ii.Quantity).IsRequired();
                    a.Property(ii => ii.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
                    a.Property(ii => ii.Amount).HasColumnType("decimal(18,2)").IsRequired();
                });

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Subtotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.SalesTax)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.TotalAmountDue)
                .HasColumnType("decimal(18,2)");
        }
    }
}